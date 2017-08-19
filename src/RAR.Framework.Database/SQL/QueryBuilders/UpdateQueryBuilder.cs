using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.SQL.QueryBuilders
{
    public class UpdateQueryBuilder : QueryBuilder
    {
        List<Object> ValueList = new List<Object>();

        public UpdateQueryBuilder()
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

        public String GetSetClause()
        {
            String sql = String.Empty;

            for(int i = 0; i < FieldList.Count; i++)
                sql += String.Format("{0} = {1},\r\n       ", FieldList[i], (ValueList[i] == null ? "null" : GetQuotedValue(ValueList[i])));
            
            sql = sql.Substring(0, sql.LastIndexOf(",\r\n       "));

            return sql.Trim();
        }

        public override String ToString()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine(String.Format("UPDATE {0}", base.GetFromClause()));
                sql.AppendLine(String.Format("   SET {0}", GetSetClause()));
                sql.AppendLine(String.Format(" WHERE {0}", base.GetWhereClause()));

                return sql.ToString().Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}