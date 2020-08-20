using System;
using System.Data;
using System.Data.Odbc;

using Necql.Database.Factories;
using Necql.Database.Interfaces;

namespace Necql.Database {
  /// <summary>
  /// Database connection struct
  /// </summary>
  public class Connection {
    private IBaseProvider _databaseProvider;

    /// <summary>
    /// Create new database connection with database provider
    /// </summary>
    /// <param name="options">Database connection options</param>
    public Connection (DatabaseOptions options) {
      this._databaseProvider = Provider.GetProvider (options);
      this._databaseProvider.Connect ();
    }

    /// <summary>
    /// Connect to database using provider
    /// </summary>
    /// <returns>Tuple response with database connection or error</returns>
    public (IDbConnection, string) Connect () {
      return this._databaseProvider.Connect ();
    }

    /// <summary>
    /// Disconnect from database using provider
    /// </summary>
    public void Disconnect () {
      this._databaseProvider.Disconnect ();
    }

    /// <summary>
    /// Check if provider is connected to database
    /// </summary>
    /// <returns>Boolean</returns>
    public bool IsConnected () {
      return this._databaseProvider.IsConnected ();
    }

    /// <summary>
    /// Execute SQL with database provider
    /// </summary>
    /// <param name="query">Query as string</param>
    /// <returns>Tuple response with last inserted id or error</returns>
    public (dynamic, string) Execute (string query) {
      return this._databaseProvider.Execute (query);
    }

    /// <summary>
    /// Get data from database provider with SQL
    /// </summary>
    /// <param name="query">Query as string</param>
    /// <returns>Tuple response with result set or error</returns>
    public (IDataReader, string) GetData (string query) {
      return this._databaseProvider.GetData (query);
    }

    /// <summary>
    /// Get connection string from database provider
    /// </summary>
    /// <returns>Connection string</returns>
    public string GetConnectionString () {
      return this._databaseProvider.GetConnectionString ();
    }
  }
}
