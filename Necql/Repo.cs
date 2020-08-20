using System;
using System.Collections.Generic;

using Necql.Configurations;
using Necql.Database;

namespace Necql {
  /// <summary>
  /// 
  /// </summary>
  public class Repo {
    private RepoOptions _repoOptions;
    private Connection _connection;

    /// <summary>
    /// Start new process of Repo
    /// </summary>
    public Repo (RepoOptions options) {
      this._repoOptions = options;
      this.Connect ();
    }

    /// <summary>
    /// Get repo options
    /// </summary>
    /// <returns></returns>
    public RepoOptions GetConfig () {
      return this._repoOptions;
    }

    /// <summary>
    /// Connect to database
    /// </summary>
    private void Connect () {
      this._connection = new Connection (this._repoOptions.Options);
    }
  }
}