using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.SQL.QueryBuilders
{
    public class InsertQueryBuilder : QueryBuilder
    {
        List<Object> ValueList = new List<Object>();

        public InsertQueryBuilder()
        {

        }

        public void AddValue(Object Value)
        {
            try
            {
                ValueList.Add(Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private String GetValueClause()
        {
            String sql = String.Empty;

            foreach (Object value in ValueList)
                sql += String.Format("{0}, ", (value == null ? "null" : GetQuotedValue(value)));

            sql = sql.Substring(0, sql.LastIndexOf(", "));

            return sql.Trim();
        }

        public override String ToString()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(String.Format("INSERT INTO {0} ", base.GetFromClause()));
                sql.Append(String.Format("({0})", base.GetFieldClause()));
                sql.Append(String.Format(" VALUES "));
                sql.Append(String.Format("({0})", GetValueClause()));

                return sql.ToString().Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}