using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR_Project.Application;
using HR_Project.Domain.Entitites;
using HR_Project.Persistence.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using HR_Project.Domain.Entitites.Common;
using System.Collections;

namespace HR_Project.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly HRProjectAPIDBContext db;

        public BaseRepository(HRProjectAPIDBContext db) 
        {
            this.db = db;
        }
        public DbSet<T> Table => db.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.Status = Domain.Enums.Status.Active;
                await Table.AddAsync(model);
                return await db.SaveChangesAsync()> 0;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await Table.ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await Table.FindAsync(id);
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> RemoveAsync(T model)
        {
            try
            {
                model.DeletedDate = DateTime.Now;
                model.Status = Domain.Enums.Status.Passive;
                Table.Update(model);
                return await db.SaveChangesAsync() > 0;


            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }


        public async Task<bool> UpdateAsync(T model)
        {
            try
            {
                model.UpdatedDate = DateTime.Now;
                model.Status = Domain.Enums.Status.Modified;
                Table.Update(model);
                return await db.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}