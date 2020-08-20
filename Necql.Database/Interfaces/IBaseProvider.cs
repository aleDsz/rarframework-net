using System;
using System.Data;

namespace Necql.Database.Interfaces {
  /// <summary>
  /// Interface for database provider
  /// </summary>
  public interface IBaseProvider {
    public (IDbConnection, string) Connect ();
    public void Disconnect ();
    public bool IsConnected ();
    public void Configure (DatabaseOptions options);
    public string GetConnectionString ();
    public (IDataReader, string) GetData (string query);
    public (dynamic, string) Execute (string query);
    public dynamic GetLastId ();
  }
}
