using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace RAR.Framework.Database.SQL.QueryBuilders
{
    public class QueryBuilder
    {
        protected List<String> FieldList = new List<String>();
        protected List<String> FromList = new List<String>();
        protected List<String> WhereList = new List<String>();

        public QueryBuilder()
        {

        }

        public void AddField(String Field)
        {
            try
            {
                FieldList.Add(Field);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddFrom(String From)
        {
            try
            {
                FromList.Add(From);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddWhere(String Where)
        {
            try
            {
                WhereList.Add(Where);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GetFieldClause()
        {
            String sql = String.Empty;

            foreach (String field in FieldList)
                sql += String.Format("{0}, ", field);

            sql = sql.Substring(0, sql.LastIndexOf(", "));

            return sql.Trim();
        }

        public String GetFromClause()
        {
            String sql = String.Empty;

            foreach (String from in FromList)
                sql += String.Format("{0}, ", from);

            sql = sql.Substring(0, sql.LastIndexOf(", "));

            return sql.Trim();
        }

        public String GetWhereClause()
        {
            String sql = String.Empty;

            foreach (String where in WhereList)
                sql += String.Format("{0}\r\n   AND ", where);

            sql = sql.Substring(0, sql.LastIndexOf("\r\n   AND "));

            return sql.Trim();
        }

        public String GetQuotedValue(Object Prop)
        {
            switch(Prop.GetType().ToString())
            {
                case "System.String":
                case "System.Double":
                case "System.TimeSpan":
                    return String.Format("'{0}'", Prop);

                case "System.DateTime":
                    var dateTime = DateTime.Parse(Prop.ToString());
                    return String.Format("'{0}'", dateTime.ToString("yyyy-MM-dd"));

                case "System.Decimal":
                    return String.Format("'{0}'", Decimal.Parse(Prop.ToString()).ToString("0.00").Replace(",", "."));

                case "System.Byte[]":
                    MemoryStream ms = new MemoryStream((Prop as Byte[]));
                    return String.Format("{0}", ms.Read((Prop as Byte[]), 0, (Prop as Byte[]).Length));

                default:
                    return String.Format("{0}", Prop);
            }
        }
    }
}