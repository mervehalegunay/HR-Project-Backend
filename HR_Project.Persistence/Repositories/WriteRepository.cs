using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Project.Application;
using HR_Project.Domain.Entitites.Common;
using HR_Project.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HR_Project.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : IBaseEntity
    {
        private readonly HRProjectAPIDBContext db;
        
        public WriteRepository(HRProjectAPIDBContext db)
        {
            this.db = db;
        }
        public bool Add(T model)
        {
            db.Add(model);
            return db.SaveChanges() > 0;
            
        }

        public bool AddRange(List<T> values)
        {
           db.AddRange(values);
            return db.SaveChanges() > 0;
        }

        public bool Delete(T model)
        {
             db.Remove(model);
            return db.SaveChanges() > 0;
        }

        public bool DeleteRange(List<T> values)
        {
              db.RemoveRange(values);
             return db.SaveChanges() > 0;
        }

        public bool Update(T model)
        {
             db.Update(model);
            return db.SaveChanges() > 0;
        }
   }
}