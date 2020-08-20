using System;
using System.Data;

using Necql.Database;
using Necql.Database.Interfaces;

namespace Necql.Sql.Providers {
  public class Sql : IBaseProvider {
    public Sql () { }

    public void Configure (DatabaseOptions options) {
      throw new NotImplementedException ();
    }

    public (IDbConnection, string) Connect () {
      throw new NotImplementedException ();
    }

    public void Disconnect () {
      throw new NotImplementedException ();
    }

    public (dynamic, string) Execute (string query) {
      throw new NotImplementedException ();
    }

    public string GetConnectionString () {
      throw new NotImplementedException ();
    }

    public (IDataReader, string) GetData (string query) {
      throw new NotImplementedException ();
    }

    public dynamic GetLastId () {
      throw new NotImplementedException ();
    }

    public bool IsConnected () {
      throw new NotImplementedException ();
    }
  }
}
