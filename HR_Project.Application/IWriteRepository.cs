using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Project.Domain.Entitites.Common;

namespace HR_Project.Application
{
    public interface IWriteRepository<T> where T : IBaseEntity
    {
        Task<bool> Delete(T model);
        Task<bool> Add(T model);
        Task<bool> Update(T model);

        
        Task<bool> DeleteRange(List<T> values);
        Task<bool> AddRange(List<T> values);
        Task<int> SaveAsync();


    }
}