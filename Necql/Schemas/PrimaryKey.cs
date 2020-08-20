using System;

using Necql.Enumerators;

namespace Necql.Schemas {
  /// <summary>
  /// Primary key definition for Schema
  /// </summary>
  [AttributeUsage (AttributeTargets.Class, AllowMultiple = true)]
  public class PrimaryKey : Attribute {
    /// <summary>
    /// Primary key field
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Primary key type
    /// </summary>
    public PrimaryKeys Type { get; set; }

    /// <summary>
    /// Should auto generate value?
    /// </summary>
    public bool AutoGenerate { get; set; }
  }
}
