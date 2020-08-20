using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

using Necql.Configurations;

namespace Necql {
  public class Changeset {
    private readonly string[] _emptyValues = new string[1] { "" };

    private Schema _schema = null;
    private dynamic _data = null;
    private List<string> _requiredFields = new List<string> ();
    private Dictionary<string, dynamic> _changes = new Dictionary<string, dynamic> ();
    private List<IDictionary<string, Object>> _errors = new List<IDictionary<string, Object>> ();
    private bool _isValid = false;
    private Repo _repo = null;
    private RepoOptions _repoOptions = new RepoOptions ();

    /// <summary>
    /// Returns if Changeset is valid
    /// </summary>
    public bool IsValid {
      get { return this._isValid; }
    }

    /// <summary>
    /// Returns Changeset errors
    /// </summary>
    public List<IDictionary<string, Object>> Errors {
      get { return this._errors; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="schema"></param>
    public Changeset (Schema schema) {
      this._schema = schema;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="schema"></param>
    public static Changeset New (Schema schema) {
      return new Changeset (schema);
    }

    /// <summary>
    /// Add changes to changeset property to show what changed from original state
    /// </summary>
    /// <param name="fieldName">Schema field name</param>
    /// <param name="value">Schema field value</param>
    /// <returns>Changeset</returns>
    private Changeset AddChange (string fieldName, dynamic value) {
      if (!this._changes.ContainsKey(fieldName)) {
        this._changes.Add (fieldName, value);
      }

      return this;
    }

    /// <summary>
    /// Put new error to errors list
    /// </summary>
    /// <param name="fieldName">Schema field name</param>
    /// <param name="reason">Error description</param>
    /// <returns>Changeset</returns>
    private Changeset AddError (string fieldName, string reason) {
      var error = new ExpandoObject () as IDictionary<string, Object>;
      error.Add ("Field", fieldName);
      error.Add ("Detail", reason);

      this._errors.Add (error);

      return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="shouldTrim"></param>
    /// <returns></returns>
    private bool IsMissing (dynamic value, bool shouldTrim = true) {
      return (value, shouldTrim) switch {
        (String str, true) => string.IsNullOrEmpty (str.Trim ()),
        (String str, false) => string.IsNullOrEmpty (str),
        (null, _) => true,
        _ => false
      };
    }

    private dynamic GetValue (dynamic obj, string fieldName) {
      if (obj == null) {
        return null;
      }

      PropertyInfo property = obj.GetType ().GetProperty (fieldName);

      if (property == null) {
        return null;
      }

      return property.GetValue (obj, null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="fields"></param>
    /// <returns></returns>
    public Changeset Cast (dynamic parameters, string[] fields) {
      this._data = parameters;
      var properties = this._schema.GetProperties ();
      var attributes = this._schema.GetSchemaFields ();

      foreach (var field in fields) {
        if (!properties.ContainsKey (field)) {
          throw new Exception (String.Format ("There's no field called {0} inside schema (even using attributes)", field));
        }

        var attribute = attributes
                        .Where (o => o.Name == field)
                        .FirstOrDefault ();

        if (attribute == null) {
          throw new Exception (String.Format ("There's no field called {0} inside schema (even using attributes)", field));
        }

        var value = GetValue (parameters, field);

        if (value != null) {
          var valueType = value.GetType ().Name switch {
            string t when t == "Int32" || t == "Int64" => "Integer",
            _ => value.GetType ().Name
          };

          var attributeType = attribute.Type.ToString () switch {
            "Id" => "Integer",
            "BinaryId" => "Guid",
            "Json" => "Object",
            _ => attribute.Type.ToString ()
          };

          if (valueType == attributeType) {
            this.AddChange (field, value);
          } else {
            throw new Exception (string.Format ("Field {0} is invalid", field));
          }
        } else {
          this.AddChange (field, null);
        }
      }

      return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fields"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public Changeset ValidateRequired (string[] fields, dynamic options = null) {
      var shouldTrim = true;

      if (GetValue (options, "ShouldTrim") != null) {
        shouldTrim = options["ShouldTrim"];
      }

      var fieldWithErrors = new List<string> ();

      foreach (var field in fields) {
        if (this._changes.ContainsKey(field)) {
          var value = this._changes[field];

          var isMissing = this.IsMissing (value, shouldTrim);
          var fieldExists = this._changes.ContainsKey (field);
          var isNull = value == null;

          if (!fieldExists) {
            fieldWithErrors.Add (field);
          } else if (isMissing && isNull) {
            fieldWithErrors.Add (field);
          }
        } else {
          fieldWithErrors.Add (field);
        }
      }

      if (fieldWithErrors.Count == 0) {
        var requiredFields =
          this._requiredFields
            .Concat (fields)
            .Distinct ()
            .ToList ();

        this._isValid = true;
        this._requiredFields = requiredFields;
      } else {
        foreach (var field in fieldWithErrors) {
          this._changes.Remove (field);
          this.AddError (field, "can't be blank");
          this._isValid = false;
        }
      }

      return this;
    }
  }
}
