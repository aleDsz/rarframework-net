using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using RAR.Framework.Database.Data;

namespace RAR.Framework.Database.Command
{
    public class CommandContext : IDisposable
    {
        private DbCommand Command;
        private DataContext Context;

        public CommandContext(String ssql) : this(ssql, null)
        {
        }

        public CommandContext(String ssql, DataContext context)
        {
            Initialize(context);
            Command.CommandText = ssql;
        }

        protected void Initialize(DataContext context)
        {
            try
            {
                Context = context;

                if (Context == null)
                    Context = DatabaseFactory.DataContext();

                if (Context == null)
                    throw new Exception("DataContext não foi inicializado.");

                if (Command == null)
                    Command = Context.Factory.CreateCommand();

                Command.Connection = Context.Connection;
                Command.Transaction = Context.Transaction;
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 5000;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteQuery()
        {
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DbDataReader ExecuteReader()
        {
            try
            {
                return Command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}