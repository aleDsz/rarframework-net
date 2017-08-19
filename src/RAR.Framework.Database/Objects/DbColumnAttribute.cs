using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.Objects
{
    public class DbColumnAttribute : Attribute
    {
        public DbColumnAttribute() : this (String.Empty) {}

        public DbColumnAttribute(String field) : this(field, DbType.String) {}

        public DbColumnAttribute(String field, DbType type)
        {
            FieldName = field;
            Type = type;
            PrimaryKey = false;
            Size = Int32.MaxValue;
        }
        
        public String FieldName { get; set; }
        public DbType Type { get; set; }
        public Boolean PrimaryKey { get; set; }
        public Int32 Size { get; set; }
    }
}