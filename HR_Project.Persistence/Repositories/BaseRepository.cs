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
    public class BaseRepository<T> : IBaseRepository<T> where T : class , IBaseEntity
    {
        private readonly HRProjectAPIDBContext db;

        public BaseRepository(HRProjectAPIDBContext context)
        {
            db = context;
        }

        public DbSet<T> Table => db.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    await Table.AddAsync(model);
                    await db.SaveChangesAsync();

                    // Eğer her şey başarılı ise, commit
                    await transaction.CommitAsync();
                    return true;
                }
                catch (System.Exception ex)
                {
                    // Hata loglama
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                    // Eğer bir hata olursa, değişiklikleri geri al
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }


        public async Task<bool> AddRangeAsync(List<T> datas)
        {
           using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    await Table.AddRangeAsync(datas);
                    await db.SaveChangesAsync();

                    // Eğer her şey başarılı ise, commit
                    await transaction.CommitAsync();
                    return true;
                }
                catch (System.Exception ex)
                {
                    // Hata loglama
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                    // Eğer bir hata olursa, değişiklikleri geri al
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        // public bool Remove(T model)
        // {
        //     EntityEntry<T> entityEntry = Table.Remove(model);
        //     return entityEntry.State == EntityState.Deleted;
        // }

        // public async Task<bool> RemoveAsync(int id)
        // {
        //     using (var transaction = await db.Database.BeginTransactionAsync())
        //     {
        //         try
        //         {
        //             T model = await Table.FirstOrDefaultAsync(a=>a.Id == id);
        //             bool removeResult = await RemoveAsync(model);

        //             if (removeResult)
        //             {
        //                 // Eğer her şey başarılı ise, commit
        //                 await transaction.CommitAsync();
        //             }
        //             else
        //             {
        //                 // Eğer bir hata olursa, değişiklikleri geri al
        //                 await transaction.RollbackAsync();
        //             }

        //             return removeResult;  // Bu satır çalışacak
        //         }
        //         catch (System.Exception ex)
        //         {
        //             // Hata loglama
        //             Console.WriteLine($"Hata oluştu: {ex.Message}");
        //             // Eğer bir hata olursa, değişiklikleri geri al
        //             await transaction.RollbackAsync();
        //             return false;
        //         }
        //     }
        // }


        // public bool RemoveRange(List<T> datas)
        // {
        //     Table.RemoveRange(datas);
        //     return true;
        // }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await db.SaveChangesAsync();


        public async Task<IEnumerable<T>> GetAll(bool tracking = true)
        {
            // var query = Table.AsQueryable();
            // if (!tracking)
            //     query = query.AsNoTracking();
            // return query;
            return await Table.ToListAsync();
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<T> datas)
        {
            throw new NotImplementedException();
        }
    }
}