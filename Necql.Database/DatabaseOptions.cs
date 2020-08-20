using System;

using Necql.Database.Interfaces;

namespace Necql.Database {
  /// <summary>
  /// Database options to connect
  /// </summary>
  public class DatabaseOptions {
    /// <summary>
    /// Database unique identifier
    /// </summary>
    public string Identifier { get; set; }

    /// <summary>
    /// Database name
    /// </summary>
    public string DatabaseName { get; set; }

    /// <summary>
    /// Username to access database
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Password to access database
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Database port
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Database host
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// Database protocol
    /// </summary>
    public string Protocol { get; set; }

    /// <summary>
    /// Database provider
    /// </summary>
    public IBaseProvider Provider { get; set; }
  }
}
