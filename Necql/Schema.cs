using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

using Necql.Schemas;

namespace Necql {
  /// <summary>
  /// Schema Manager
  /// </summary>
  public class Schema : DynamicObject {
    private Dictionary<string, dynamic> _properties;
    private PrimaryKey _primaryKey;
    private List<Field> _attributes;

    public bool XD { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Schema () {
      this._properties = new Dictionary<string, dynamic> ();
      this._attributes = new List<Field> ();
      
      this.GeneratePrimaryKey ();
      this.GenerateProperties ();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="binder"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public override bool TryGetMember (GetMemberBinder binder, out dynamic result) {
      if (_properties.ContainsKey (binder.Name)) {
        result = _properties[binder.Name];
        return true;
      } else {
        result = null;
        return false;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="binder"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public override bool TrySetMember (SetMemberBinder binder, dynamic value) {
      if (_properties.ContainsKey (binder.Name)) {
        _properties[binder.Name] = value;
        return true;
      } else {
        return false;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private void GeneratePrimaryKey () {
      try {
        var type = this.GetType ();

        var primaryKeyAttribute =
          type
          .GetCustomAttribute (typeof (PrimaryKey), true);

        if (primaryKeyAttribute != null) {
          this._primaryKey = (PrimaryKey) primaryKeyAttribute;

          if (string.IsNullOrEmpty (this._primaryKey.Name)) {
            throw new Exception ("There's no name for this field");
          }

          this._properties.Add (this._primaryKey.Name, null);
        }
      } catch (Exception ex) {
        throw ex;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private void GenerateProperties () {
      try {
        var type = this.GetType ();
        var constructors = type.GetConstructors ();

        var fieldAttributes =
          constructors
          .First ()
          .GetCustomAttributes (typeof(Field), false)
          .ToList ();

        if (fieldAttributes.Count () > 0) {
          foreach (Field fieldAttribute in fieldAttributes) {
            var name = fieldAttribute.Name;

            if (string.IsNullOrEmpty (name)) {
              throw new Exception ("There's no name for this field");
            }

            this._attributes.Add (fieldAttribute);
            this._properties.Add (name, null);
          }
        }
      } catch (Exception ex) {
        throw ex;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, dynamic> GetProperties () {
      return this._properties;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<dynamic> GetSchemaFields () {
      var schemaFields = new List<dynamic> ();
      schemaFields.Add (this._primaryKey);

      foreach (var o in this._attributes) {
        schemaFields.Add (o);
      }

      return schemaFields;
    }
  }
}
