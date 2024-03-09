using HR_Project.Domain.Entitites;
using HR_Project.Domain.Entitites.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application
{
    public interface IBaseRepository <T> where T :  IBaseEntity
    {
        Task<T> GetById(int id);
        Task<T> GetByExpression(Expression<Func<T, bool>> expression);

        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<int> SaveChange();
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null);
        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<T, TResult>> select = null,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
            );

        Task<List<TResult>> GetFilteredList<TResult>(
       Expression<Func<T, TResult>> select = null,
       Expression<Func<T, bool>> where = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
       );

        Task<T> GetFilteredInclude(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);


    }
}
