using System;

using Necql.Enumerators;

namespace Necql.Schemas {
  /// <summary>
  /// Field definition for Schema
  /// </summary>
  [AttributeUsage (AttributeTargets.All, AllowMultiple = true)]
  public class Field : Attribute {
    /// <summary>
    /// Field name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Field type
    /// </summary>
    public FieldTypes Type { get; set; }

    /// <summary>
    /// Field default value
    /// </summary>
    public dynamic Default { get; set; }

    /// <summary>
    /// Field can be null?
    /// </summary>
    public bool Null { get; set; }

    /// <summary>
    /// Field database name
    /// </summary>
    public string Source { get; set; }
  }
}
