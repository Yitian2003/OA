using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.IDAL;
using System.Linq.Expressions;

namespace OA.IBLL
{
    public interface IBaseService <T> where T:class, new()
    {
        IDBSession DBSession { get; }
        IBaseDal<T> CurrentDal { get; set; }

        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderbyLambda, bool isAsc);

        T AddEntity(T entity);

        bool DeleteEntity(T entity);

        bool EditEntity(T entity);
    }
}
