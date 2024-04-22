using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieAPI.Domain;
using MovieAPI.Domain.Entities.Abstracts;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure
{

    
    public class GenericRepository<T> :IGenericRepository<T> where T : class, IBaseEntity
    {
        private readonly MovieAPIDbContext _context;

        public GenericRepository(MovieAPIDbContext context)
        {
            _context = context;
        }

    
        public DbSet<T> Table => _context.Set<T>();

        #region Read Repositories

        
        public async Task<IQueryable<T>> GetAllAsync()
        { 
            var getQuery = Table;
            return await Task.FromResult(getQuery);
        }

        public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> method)
        {
            var query = Table.Where(method);
            return await Task.FromResult(query);
        } 

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {   
          return await Table.FirstOrDefaultAsync(method);
            
        }
        public async Task<T> GetByIdAsync(int id)
        {
           return await Table.FindAsync(id);
        }
        #endregion



        #region Write Methods 
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            await SaveAsync();
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            await SaveAsync();
            return true;
        }

        public async Task<bool> Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            await SaveAsync();
            return entityEntry.State == EntityState.Modified;

        }

        public async Task<bool> Remove(T model)
        {
            if (model is ISoftDelete)
            {
                ((ISoftDelete)model).IsDeleted = true;
                return await Update(model);
            }
            else
            {
                EntityEntry<T> entityEntry = Table.Remove(model);
                await SaveAsync();
                return entityEntry.State == EntityState.Deleted;

            }
        }

        public async Task<bool> RemoveRange(List<T> datas)
        {
            foreach (var item in datas)
            {
               await Remove(item);
            }
            return true;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
           var model = await Table.FirstOrDefaultAsync(data => data.Id == id);
           return await Remove(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        #endregion


    }
}
