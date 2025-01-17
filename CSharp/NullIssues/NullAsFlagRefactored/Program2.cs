﻿using System;

namespace NullAsFlagRefactored
{
    class Program2
    {
        static void Main2(string[] args)
        {
            var myNotificationsEngine = new MyNotificationsEngine();

            var localDataCenter = new DataCenter();
            var remoteDataCenter = new DataCenter();

            var myController = new MyController(
                myNotificationsEngine, 
                localDataCenter, 
                remoteDataCenter);

            //somewhere
            myController.HandleMessageFromUser("message1");


            //somewhere else
            myController.HandleReplicatedMessage("message2");
        }
    }

    internal class MyController
    {
        private readonly MyNotificationsEngine _myNotificationsEngine;
        private readonly IDataCenter _localDataCenter;
        private readonly IDataCenter _remoteDataCenter;

        public MyController(
            MyNotificationsEngine myNotificationsEngine, 
            IDataCenter localDataCenter, 
            IDataCenter remoteDataCenter)
        {
            _myNotificationsEngine = myNotificationsEngine;
            _localDataCenter = localDataCenter;
            _remoteDataCenter = remoteDataCenter;
        }

        public void HandleMessageFromUser(string message)
        {
            _myNotificationsEngine.NotifyNewData(_localDataCenter, _remoteDataCenter, message);
        }

        public void HandleReplicatedMessage(string message)
        {
            _myNotificationsEngine.NotifyNewData(
                _localDataCenter, 
                new IgnoreThisDataCenter(), 
                message);
        }
    }

    internal class IgnoreThisDataCenter : IDataCenter
    {
        public void Send(string message)
        {
            //EMPTY
        }
    }

    public interface IDataCenter
    {
        void Send(string message);
    }

    public class DataCenter : IDataCenter
    {
        public void Send(string message)
        {
            Console.WriteLine(message);     
        }
    }

    internal class MyNotificationsEngine
    {
        public void NotifyNewData(
            IDataCenter localDataCenter, 
            IDataCenter remoteDataCenter, 
            string message)
        {
            localDataCenter.Send(message);
            remoteDataCenter.Send(message);
        }
    }
}
