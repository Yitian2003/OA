using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DAL;
using OA.Factory;
using OA.IDAL;
using OA.Model;
using System.Linq.Expressions;

namespace OA.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public BaseService()
        {
            SetCurrentDal();
        }
        public IDBSession DBSession
        {
            get
            {
                //return new DBSession();
                return DBSessionFactory.CreateDBSession();
            }
        }

        public IBaseDal<T> CurrentDal { get; set; }

        public abstract void SetCurrentDal();

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }

        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            DBSession.SaveChanges();
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return DBSession.SaveChanges();
        }

        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return DBSession.SaveChanges();
        }

    }
}
