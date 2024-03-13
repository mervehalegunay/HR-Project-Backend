using HR_Project.Domain.Entitites;
using HR_Project.Domain.Entitites.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application
{
    public interface IBaseRepository <T> where T :  class, IBaseEntity
    {
        DbSet<T> Table { get; }
        Task<bool> AddAsync(T model);
        Task<bool> RemoveAsync(T model);
        Task<bool> UpdateAsync(T model);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetByIdAsync(int id);

        Task<TResult> GetFilteredFirstOrDefault<TResult>(
    Expression<Func<T, TResult>> select = null,
    Expression<Func<T, bool>> where = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    );


    }
}
