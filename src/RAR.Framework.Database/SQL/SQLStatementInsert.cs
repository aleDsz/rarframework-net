using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAR.Framework.Database.Enums;
using RAR.Framework.Database.Objects;
using RAR.Framework.Database.SQL.QueryBuilders;

namespace RAR.Framework.Database.SQL
{
    public class SQLStatementInsert<T> : SQLStatement
    {
        T Object;
        InsertQueryBuilder ssql = new InsertQueryBuilder();

        public SQLStatementInsert(T obj)
        {
            Object = obj;
        }

        private void CreateSQL()
        {
            try
            {
                ObjectContext<T> context = new ObjectContext<T>(Object);
                List<Properties> props = context.GetProperties(true).Where(p => p.Type != System.Data.DbType.Object).ToList();
                ssql.AddFrom(context.GetTable());

                foreach(Properties Property in props)
                {
                    ssql.AddField(Property.FieldName);
                    ssql.AddValue(Property.Value);
                }
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