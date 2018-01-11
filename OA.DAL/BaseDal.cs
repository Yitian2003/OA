using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Model;
using System.Linq.Expressions;
using System.Data.Entity;

namespace OA.DAL
{
    public class BaseDal<T> where T : class, new()
    {
        public DbContext Db
        {
            get
            {
                return DBFactory.CreateDbContext();
            }
        }

        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
            return true;
        }

        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            return true;
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }

        /// <summary>
        /// page
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc">true is Asc,  falase is Desc</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();

            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}
