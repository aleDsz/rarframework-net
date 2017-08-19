using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.Objects
{
    public class Properties
    {
        public Properties()
        {
            PropName = String.Empty;
            FieldName = String.Empty;
            Type = DbType.StringFixedLength;
            PrimaryKey = false;
            Value = null;
            Size = Int32.MaxValue;
        }

        public Properties(String prop, String field, DbType type, Boolean pk, Object value, Int32 size)
        {
            PropName = prop;
            FieldName = field;
            Type = type;
            PrimaryKey = pk;
            Value = value;
            Size = size;
        }

        public String PropName { get; set; }
        public String FieldName { get; set; }
        public DbType Type { get; set; }
        public Boolean PrimaryKey { get; set; }
        public Object Value { get; set; }
        public Int32 Size { get; set; }
    }
}