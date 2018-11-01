using CXCVCapitalIntrant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CXCVCapitalIntrant.DAL
{
    internal class DBContextFactory
    {
        internal static cvcxcapital_sysdataEntities CreateContext()
        {
            cvcxcapital_sysdataEntities db = CallContext.GetData("dbContext") as cvcxcapital_sysdataEntities;
            if (db != null) return db;
            db = new cvcxcapital_sysdataEntities();
            CallContext.SetData("dbContext", db);
            return db;
        }
    }
}
