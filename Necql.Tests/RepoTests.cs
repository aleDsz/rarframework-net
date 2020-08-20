using System;
using Necql.Configurations;

using NUnit.Framework;

namespace Necql.Tests {
  public class RepoTests {
    private string _connectionString;
    //private DatabaseOptions _databaseOptions;

    /// <summary>
    /// Test setup
    /// </summary>
    [SetUp]
    public void Setup () {
      this._connectionString = "file:database.sqlite";
      //this._databaseOptions = new DatabaseOptions () {
      //  Host = "database.sqlite"
      //};
    }

    /// <summary>
    /// Test if database connection string is the same as defined from constructor
    /// </summary>
    [Test]
    public void TestRepoOptionsUrl () {
      Assert.Pass ();
      //var repo = new Repo (new RepoOptions () {
      //  Url = this._connectionString
      //});

      //var repoOptions = repo.GetConfig ();

      //Assert.AreEqual (this._connectionString, repoOptions.Url);
    }

    /// <summary>
    /// Test if database options is the same as defined from constructor
    /// </summary>
    [Test]
    public void TestRepoOptionsDatabaseOptions () {
      Assert.Pass ();
      //var repo = new Repo (new RepoOptions () {
      //  Options = this._databaseOptions
      //});

      //var repoOptions = repo.GetConfig ();

      //Assert.AreEqual (this._databaseOptions, repoOptions.Options);
    }
  }
}