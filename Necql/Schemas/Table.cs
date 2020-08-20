using System;

namespace Necql.Schemas {
  /// <summary>
  /// Schema definition for database table
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public class Table : Attribute {
    /// <summary>
    /// Table/Collection's name
    /// </summary>
    public string Name { get; set; }
  }
}
