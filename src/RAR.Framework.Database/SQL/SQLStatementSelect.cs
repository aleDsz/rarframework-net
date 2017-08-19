using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RAR.Framework.Database.Enums;
using RAR.Framework.Database.Objects;
using RAR.Framework.Database.SQL.QueryBuilders;

namespace RAR.Framework.Database.SQL
{
    public class SQLStatementSelect<T> : SQLStatement
    {
        T Object;
        SelectQueryBuilder ssql = new SelectQueryBuilder();

        public SQLStatementSelect(T obj)
        {
            Object = obj;
        }

        private void CreateSQL(Boolean isList)
        {
            try
            {
                ObjectContext<T> context = new ObjectContext<T>(Object);
                List<Properties> props = context.GetProperties(isList);
                List<Properties> fields = context.GetProperties(true);
                ssql.AddFrom(context.GetTable());

                if (!isList)
                {
                    IEnumerable<Properties> pks =
                           from prop in props
                          where prop.PrimaryKey == true
                         select prop;

                    if (pks.ToList().Count == 0)
                        throw new Exception("Informar pelo menos 1 Primary Key");
                }

                foreach (Properties Property in fields)
                    ssql.AddField(Property.FieldName);

                foreach (Properties Property in props)
                    if (Property.Value != null)
                        ssql.AddWhere(String.Format("{0} {1}", Property.FieldName, base.GetQuotedValue(Property.Value, Property.Type)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GetSQL()
        {
            try
            {
                return GetSQL(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GetSQL(TiposSelect TipoSelect)
        {
            try
            {
                return GetSQL(Convert.ToBoolean((Int16)TipoSelect));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GetSQL(Boolean isList)
        {
            try
            {
                CreateSQL(isList);
                return ssql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}