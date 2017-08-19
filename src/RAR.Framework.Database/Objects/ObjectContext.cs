using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Data;

namespace RAR.Framework.Database.Objects
{
    public class ObjectContext<T>
    {
        T Obj;

        public ObjectContext(T obj)
        {
            Obj = obj;
        }

        public List<Properties> GetProperties(Boolean GetNull)
        {
            List<Properties> Props = new List<Properties>();

            Type ObjType = Obj.GetType();
            IList<PropertyInfo> PropInfo = ObjType.GetProperties().ToList();

            foreach (PropertyInfo Prop in PropInfo)
            {
                object[] attributes = Attribute.GetCustomAttributes(Prop);
                foreach (Attribute Attributes in attributes)
                {
                    var attr = Attributes as DbColumnAttribute;
                    if (attr != null)
                    {
                        if (GetNull)
                            Props.Add(new Properties(Prop.Name, attr.FieldName, attr.Type, attr.PrimaryKey, Prop.GetValue(Obj, null), attr.Size));
                        else
                            if (Prop.GetValue(Obj, null) != null)
                                Props.Add(new Properties(Prop.Name, attr.FieldName, attr.Type, attr.PrimaryKey, Prop.GetValue(Obj, null), attr.Size));
                    }
                }
            }

            return Props;
        }

        public String GetTable()
        {
            String Table = String.Empty;

            Type ObjType = Obj.GetType();
            var Attributes = ObjType.GetCustomAttributes(true);

            foreach (Attribute Attribute in Attributes)
            {
                var attr = Attribute as DbTableAttribute;
                if (attr != null)
                {
                    Table = attr.TableName;
                }
            }

            return Table;
        }

        private TValue GetNullableValue<TValue>(Object Value)
        {
            if (DBNull.Value.Equals(Value))
                return default(TValue);
            else
                return (TValue)Value;
        }

        public T GetObject<T>(DbDataReader result) where T : class
        {
            T Object = null;
            Type type = Obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

            if (result.Read())
            {
                Object = (T)Activator.CreateInstance(type);

                foreach (PropertyInfo prop in props)
                {
                    object[] attributes = Attribute.GetCustomAttributes(prop);
                    foreach (Attribute Attributes in attributes)
                    {
                        var attr = Attributes as DbColumnAttribute;
                        if (attr != null)
                            prop.SetValue(Object, GetNullableValue<T>(result[attr.FieldName]), null);
                    }
                }
            }

            return Object;
        }

        public List<T> GetObjects<T>(DbDataReader result) where T : class
        {
            List<T> listObject = null;
            Type type = Obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

            while (result.Read())
            {
                var newObject = Activator.CreateInstance(type);
                if (listObject == null)
                    listObject = new List<T>();

                foreach (PropertyInfo prop in props)
                {
                    object[] attributes = Attribute.GetCustomAttributes(prop);
                    foreach (Attribute Attributes in attributes)
                    {
                        var attr = Attributes as DbColumnAttribute;
                        if (attr != null)
                            prop.SetValue(newObject, GetNullableValue<T>(result[attr.FieldName]), null);
                    }
                }
                
                listObject.Add((T)newObject);
            }

            return listObject;
        }
    }
}