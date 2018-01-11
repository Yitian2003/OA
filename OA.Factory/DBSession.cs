using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Model;
using OA.DAL;
using OA.IDAL;
using System.Data.Entity;

namespace OA.Factory
{
    /// <summary>
    /// call specific Dal, call db
    /// </summary>
    public class DBSession : IDBSession
    {
        private IUserInfoDal _UserInfoDal;
        
        public DbContext Db
        {
            get { return DBFactory.CreateDbContext(); }
        }
        
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if(_UserInfoDal == null)
                {
                    _UserInfoDal = DALFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set
            {
                _UserInfoDal = value;
            }
        }

        /// <summary>
        /// call multiple tables, only operate database once
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }

    
}
