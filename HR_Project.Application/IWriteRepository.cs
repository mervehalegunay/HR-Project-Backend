using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Project.Domain.Entitites.Common;

namespace HR_Project.Application
{
    public interface IWriteRepository<T> where T : IBaseEntity
    {
        bool Delete(T model);
        bool Add(T model);
        bool Update(T model);

        
        bool DeleteRange(List<T> values);
        bool AddRange(List<T> values);



    }
}