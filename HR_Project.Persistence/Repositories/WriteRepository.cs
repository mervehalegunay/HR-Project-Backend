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
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IBaseEntity
    {
        private readonly HRProjectAPIDBContext db;

        public WriteRepository(HRProjectAPIDBContext db)
        {
            this.db = db;
        }
        DbSet<T> table => db.Set<T>();
        public async Task<bool> Add(T model)
        {
            model.CreatedDate = DateTime.Now;
            EntityEntry<T> entityEntry = await table.AddAsync(model);
            return entityEntry.State == EntityState.Added;

        }

        public async Task<bool> AddRange(List<T> values)
        {
            foreach (var item in values)
            {
                item.CreatedDate = DateTime.Now;
            }
            await table.AddRangeAsync(values);
            return true;
        }

        public async Task<bool> Delete(T model)
        {
            model.DeletedDate = DateTime.Now;
            EntityEntry<T> entityEntry = table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteRange(List<T> values)
        {
            foreach (var item in values)
            {
                item.DeletedDate = DateTime.Now;
            }
            table.RemoveRange(values);
            return true;
        }

        public async Task<bool> Update(T model)
        {
            model.UpdatedDate = DateTime.Now;
            EntityEntry entityEntry = table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await db.SaveChangesAsync();
    }
}