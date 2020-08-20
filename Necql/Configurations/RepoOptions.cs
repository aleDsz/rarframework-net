using System;
using System.Security.Policy;

using Necql.Database;

namespace Necql.Configurations {
  /// <summary>
  /// 
  /// </summary>
  public class RepoOptions {
    /// <summary>
    /// Database connection string
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Database options to connect when Database connection string isn't defined
    /// </summary>
    public DatabaseOptions Options { get; set; }

    /// <summary>
    /// Database connection/execution timeout
    /// </summary>
    public int Timeout { get; set; }

    /// <summary>
    /// Get connection string from options
    /// </summary>
    /// <returns>Connection string</returns>
    public string GetConnectionString () {
      return this.Options.Provider.GetConnectionString ();
    }
  }
}
