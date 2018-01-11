using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OA.Model;

namespace OA.DAL
{
    public class DBFactory
    {
        /// <summary>
        /// ef context instance is unique in thread
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext db = (DbContext)CallContext.GetData("dbContext");

            if(db == null)
            {
                db = new OuOAEntities();
                CallContext.SetData("dbContext", db);
            }
            return db;
        }
    }
}
