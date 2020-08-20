using System;
using System.Linq;
using Necql.Enumerators;
using Necql.Schemas;

namespace Necql.Tests.Supports.Schemas {
  /// <summary>
  /// Schema definitions for users table
  /// </summary>
  [Table (Name = "users")]
  [PrimaryKey(Name = "Id", Type = PrimaryKeys.BinaryId, AutoGenerate = true)]
  public class User : Schema {
    [Field (Name = "Name", Type = FieldTypes.String, Source = "name")]
    [Field (Name = "Age", Type = FieldTypes.Integer, Source = "age")]
    public User () : base() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="schema"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static Changeset Validate (Schema schema, dynamic parameters) {
      return
        Changeset
        .New (schema)
        .Cast (parameters, new[] { "Name", "Age" })
        .ValidateRequired (new[] { "Name", "Age" });
    }
  }
}
