using System;
using System.Collections.Generic;

namespace Necql.Database.Models {
  /// <summary>
  /// Query definition to execute statements
  /// </summary>
  public class Query {
    /// <summary>
    /// A dictionary with all from tables using alias and Schema
    /// </summary>
    public Dictionary<string, dynamic> From { get; set; }

    /// <summary>
    /// Fields used to generate statement
    /// </summary>
    public List<string> Fields { get; set; }

    /// <summary>
    /// Parameters to prepare statement to execute query
    /// </summary>
    public dynamic Parameters { get; set; }
  }
}
