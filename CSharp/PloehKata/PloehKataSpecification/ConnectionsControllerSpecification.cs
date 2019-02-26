﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PloehKata;
using TddXt.AnyRoot.Strings;
using Xunit;
using static TddXt.AnyRoot.Root;

namespace PloehKataSpecification
{
  public class ConnectionsControllerSpecification
  {
    [Fact]
    public void ShouldForwardLogicToConnectCommand()
    {
      //GIVEN
      var connectCommand = Substitute.For<IUserCommand>();
      var resultFromConnection = Any.Instance<IActionResult>();
      var connectionInProgress = Substitute.For<IConnectionInProgress>();
      var infrastructure = Substitute.For<IUserInfrastructure>();
      var user1Id = Any.String();
      var user2Id = Any.String();
      var connectionsController = new ConnectionsController(infrastructure);

      infrastructure.CreateConnectionInProgress().Returns(connectionInProgress);
      infrastructure.CreateConnectionCommand(connectionInProgress, user1Id, user2Id).Returns(connectCommand);
      connectionInProgress.ToActionResult().Returns(resultFromConnection);

      //WHEN
      var actionResult = connectionsController.Connect(user1Id, user2Id);

      //THEN
      connectCommand.Received(1).Execute();
      actionResult.Should().Be(resultFromConnection);
    }
  }
}