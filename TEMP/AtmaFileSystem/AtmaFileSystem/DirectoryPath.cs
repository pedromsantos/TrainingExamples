using System;
using System.IO;

namespace AtmaFileSystem
{
  public class DirectoryPath : IEquatable<DirectoryPath>
  {
    public bool Equals(DirectoryPath other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return string.Equals(_path, other._path);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((DirectoryPath) obj);
    }

    public override int GetHashCode()
    {
      return _path.GetHashCode();
    }

    public static bool operator ==(DirectoryPath left, DirectoryPath right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(DirectoryPath left, DirectoryPath right)
    {
      return !Equals(left, right);
    }

    public static PathWithFileName operator /(DirectoryPath path, FileName fileName)
    {
      return PathWithFileName.From(path, fileName);
    }

    private readonly string _path;

    public DirectoryPath(string path)
    {
      _path = path;
    }

    public static DirectoryPath To(string path)
    {
      if (null == path)
      {
        throw new ArgumentNullException(path);
      }

      if (!Path.IsPathRooted(path))
      {
        throw new ArgumentException(path);
      }

      else return new DirectoryPath(path);
    }

    public override string ToString()
    {
      return _path;
    }

  }
}