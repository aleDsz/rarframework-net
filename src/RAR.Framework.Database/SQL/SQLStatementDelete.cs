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
    public class SQLStatementDelete<T> : SQLStatement
    {
        T Object;
        DeleteQueryBuilder ssql = new DeleteQueryBuilder();

        public SQLStatementDelete(T obj)
        {
            Object = obj;
        }

        private void CreateSQL()
        {
            try
            {
                ObjectContext<T> context = new ObjectContext<T>(Object);
                List<Properties> props = context.GetProperties(false);
                ssql.AddFrom(context.GetTable());

                IEnumerable<Properties> pks =
                        from prop in props
                        where prop.PrimaryKey == true
                        select prop;

                if (pks == null)
                    throw new Exception("Informar pelo menos 1 Primary Key");

                foreach(Properties Property in pks)
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
                CreateSQL();
                return ssql.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}