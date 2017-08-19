using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.SQL.QueryBuilders
{
    public class SelectQueryBuilder : QueryBuilder
    {
        public SelectQueryBuilder()
        {

        }

        public override String ToString()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                if (base.FieldList.Count > 0)
                    sql.AppendLine(String.Format("SELECT {0}", base.GetFieldClause()));
                else
                    sql.AppendLine(String.Format("SELECT *"));

                if (base.FromList.Count > 0)
                    sql.AppendLine(String.Format("  FROM {0}", base.GetFromClause()));

                if (base.WhereList.Count > 0)
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