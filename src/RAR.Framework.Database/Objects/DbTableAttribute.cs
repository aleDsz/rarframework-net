using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.Objects
{
    public class DbTableAttribute : Attribute
    {
        public DbTableAttribute(String Table)
        {
            TableName = Table;
        }

        public String TableName { get; set; }
    }
}