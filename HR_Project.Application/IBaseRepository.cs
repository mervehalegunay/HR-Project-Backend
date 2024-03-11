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
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        Task<bool> RemoveAsync(int id);
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        Task<int> SaveAsync();

        Task<IEnumerable<T>> GetAll(bool tracking = true);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);


    }
}
