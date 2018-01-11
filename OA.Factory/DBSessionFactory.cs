using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.Factory
{
    /// <summary>
    /// create DBSession
    /// </summary>
    public class DBSessionFactory
    {
        public static IDAL.IDBSession CreateDBSession()
        {
            IDBSession DbSession = (IDBSession)CallContext.GetData("dbSession");

            if(DbSession == null)
            {
                DbSession = new DBSession();
                CallContext.SetData("dbSession", DbSession);
            }

            return DbSession;
        }
    }
}
