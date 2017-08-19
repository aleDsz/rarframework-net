using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.SQL.QueryBuilders
{
    public class DeleteQueryBuilder : QueryBuilder
    {
        public DeleteQueryBuilder()
        {

        }

        public override String ToString()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine(String.Format("DELETE"));
                sql.AppendLine(String.Format("  FROM {0}", base.GetFromClause()));
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