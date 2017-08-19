using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace RAR.Framework.Database.Data
{
    public class DataContext
    {
        public DbProviderFactory Factory;
        public DbConnection Connection;
        public DbTransaction Transaction;

        public DataContext()
             : this(ConfigurationManager.AppSettings["dbConnectionName"],
                    ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["dbConnectionName"]].ConnectionString,
                    ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["dbConnectionName"]].ProviderName)
        {
        }

        public DataContext(String dbName)
             : this(dbName,
                    ConfigurationManager.ConnectionStrings[dbName].ConnectionString,
                    ConfigurationManager.ConnectionStrings[dbName].ProviderName)
        {
        }

        public DataContext(String dbName, String conString, String provider)
        {
            try
            {
                if (String.IsNullOrEmpty(dbName))
                    throw new Exception("dbConnectionName está nulo");

                if (String.IsNullOrEmpty(conString))
                    throw new Exception("ConnectionString está nulo");

                if (String.IsNullOrEmpty(provider))
                    throw new Exception("ProviderName está nulo");

                Factory = DbProviderFactories.GetFactory(provider);
                Connection = Factory.CreateConnection();
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Begin()
        {
            try
            {
                Begin(IsolationLevel.Unspecified);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Begin(IsolationLevel IsolationLevel)
        {
            try
            {
                if (Connection != null && Transaction == null)
                    Transaction = Connection.BeginTransaction(IsolationLevel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Commit()
        {
            try
            {
                if (Connection != null && Transaction != null)
                {
                    if (Transaction.Connection != null)
                        Transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Rollback()
        {
            try
            {
                if (Connection != null && Transaction != null)
                {
                    if (Transaction.Connection != null)
                        Transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}