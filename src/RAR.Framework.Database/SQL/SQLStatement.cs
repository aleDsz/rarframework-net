using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.SQL
{
    public class SQLStatement
    {
        public String GetQuotedValue(Object Prop, DbType Type)
        {
            String Result = String.Empty;

            switch (Type)
            {
                case DbType.Byte:
                case DbType.Binary:
                case DbType.Boolean:
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                case DbType.SByte:
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                case DbType.VarNumeric:
                    Result = String.Format("= {0}", Prop.ToString());
                    break;

                case DbType.Date:
                    DateTime? data = Prop as DateTime?;
                    if (data != null)
                        Result = String.Format("= '{0}'", data.Value.ToString("yyyy-MM-dd"));
                    else
                        Result = String.Format("= '{0}'", Prop.ToString());
                    break;

                case DbType.DateTime:
                    data = Prop as DateTime?;
                    if (data != null)
                        Result = String.Format("= '{0}'", data.Value.ToString());
                    else
                        Result = String.Format("= '{0}'", Prop.ToString());
                    break;

                case DbType.Time:
                    TimeSpan? hora = Prop as TimeSpan?;
                    if (hora != null)
                        Result = String.Format("= '{0}'", hora.Value.ToString(@"hh\:mm"));
                    else
                        Result = String.Format("= '{0}'", Prop.ToString());
                    break;

                case DbType.Decimal:
                default:
                    if (Prop.ToString().StartsWith("%") || Prop.ToString().EndsWith("%"))
                        Result = String.Format("LIKE '{0}'", Prop.ToString());
                    else
                        Result = String.Format("= '{0}'", Prop.ToString());
                    break;
            }

            return Result;
        }
    }
}