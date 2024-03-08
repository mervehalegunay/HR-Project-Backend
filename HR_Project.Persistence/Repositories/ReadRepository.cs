using HR_Project.Persistence.Context;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Persistence.Repositories
{
    // public class ReadRepository<T> : IReadRepository<T> where T : IBaseEntity
    // {
    //     private readonly HRProjectAPIDBContext _context;
    //     public ReadRepository(HRProjectAPIDBContext context)
    //     {
    //         _context = context;
    //     }

    //     public DbSet<T> Table => _context.Set<T>();

    //     public async Task<T> GetById(int id)
    //     {

    //         try
    //         {
    //             return await Table.FindAsync(id);

    //         }
    //         catch (Exception)
    //         {

    //             return null;
    //         }

    //     }

    //     public async Task<T> GetByExpression(Expression<Func<T, bool>> expression)
    //     {
    //         return await Table.AsNoTracking().FirstOrDefaultAsync(expression);
    //     }

    //     public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null)
    //     {
    //         if (expression == null)
    //         {
    //             return await Table.AsNoTracking().ToListAsync();
    //         }
    //         else
    //         {
    //             return await Table.AsNoTracking().Where(expression).ToListAsync();
    //         }
    //     }

    //     public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select = null, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    //     {

    //         IQueryable<T> query = Table;  // SELECT * FROM Post gibi...

    //         if (include != null)  // JOIN İŞLEMİ
    //         {
    //             query = include(query);
    //         }

    //         if (where != null) // SELECT * FOM Post WHERE Status = 1 gibi...
    //         {
    //             query = query.Where(where);
    //         }

    //         if (orderBy != null)
    //         {
    //             return await orderBy(query).Select(select).FirstOrDefaultAsync();

    //         }

    //         var result = await query.Select(select).FirstOrDefaultAsync();

    //         return result;


    //     }

    //     public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select = null, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    //     {
    //         IQueryable<T> query = Table; // SELECT * FROM Post gibi...

    //         if (where != null)   // SELECT * FOM Post WHERE Status = 1 gibi...
    //         {
    //             query = query.Where(where);
    //         }

    //         if (include != null)
    //         {
    //             query = include(query); // JOIN İŞLEMİ
    //         }


    //         if (orderBy != null)  // Sıralama işlemi varsa sıralayıp return edecek yoksa sıralamadan query'i sorgulayıop sonucu liste şeklinde return edecek.
    //         {

    //             return await orderBy(query).Select(select).ToListAsync();
    //         }

    //         var result = await query.Select(select).ToListAsync();

    //         return result;
    //     }

    //     public async Task<T> GetFilteredInclude(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    //     {
    //         IQueryable<T> query = Table;

    //         if (expression != null)
    //         {
    //             query = query.Where(expression);
    //         }
    //         if (include != null)
    //         {
    //             query = include(query);

    //         }



    //         return await query.FirstOrDefaultAsync();


    //     }


    //     public async Task<int> SaveChange()
    //     {
    //         return await _context.SaveChangesAsync();

    //     }


    // }

}
