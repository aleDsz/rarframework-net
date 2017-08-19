using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAR.Framework.Database.Data;

namespace RAR.Framework.Database
{
    public static class DatabaseFactory
    {
        private static DataContext instanceOfDataContext = null;

        public static DataContext DataContext()
        {
            if (instanceOfDataContext == null)
                instanceOfDataContext = new DataContext();
            return instanceOfDataContext;
        }
    }
}
