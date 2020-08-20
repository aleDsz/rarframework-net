using System;

using Necql.Database.Interfaces;

using NUnit.Framework;

namespace Necql.Database.Tests.Providers {
  public class PostgresTests {
    private DatabaseOptions _databaseOptions;

    /// <summary>
    /// Test setup
    /// </summary>
    [SetUp]
    public void Setup () {
      this._databaseOptions = new DatabaseOptions () {
        DatabaseName = "test",
        Host = "localhost",
        Username = "aledsz",
        Password = "",
        Port = 5432,
        Identifier = "postgres",
        Protocol = "Postgres"
      };
    }

    /// <summary>
    /// Get connection string from Postgres provider
    /// </summary>
    [Test]
    public void TestConnectionString () {
      // IBaseProvider provider = new Postgres ();
      // provider.Configure (this._databaseOptions);

      // var connectionString = provider.GetConnectionString ();

      // Assert.NotNull (connectionString);
    }

    /// <summary>
    /// Get database connection from Postgres provider
    /// </summary>
    [Test]
    public void TestConnection () {
      // IBaseProvider provider = new Postgres ();
      // provider.Configure (this._databaseOptions);

      // var connection = provider.Connect ();

      // Assert.NotNull (connection);
    }
  }
}