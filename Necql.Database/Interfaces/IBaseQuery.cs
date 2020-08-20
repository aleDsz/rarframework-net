using System;
using System.Collections.Generic;
using System.Data;

using Necql.Database.Models;

namespace Necql.Database.Interfaces {
  /// <summary>
  /// Interface for query
  /// </summary>
  public interface IBaseQuery {
    public dynamic Prepare (IDbConnection connection, Query query, Dictionary<string, dynamic> opts = null);
    public dynamic Execute (IDbConnection connection, Query query, Dictionary<string, dynamic> opts = null);
  }
}