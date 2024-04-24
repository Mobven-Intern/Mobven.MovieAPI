using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain
{
    public interface IGenericRepository<T> where T : class, IBaseEntity
    {
        DbSet<T> Table {  get; }

        
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<bool> RemoveAsync(T model);
        Task<bool> RemoveRangeAsync(List<T> datas);
        Task<bool> RemoveByIdAsync(int id);
        Task<bool> UpdateAsync(T model);
        Task SaveAsync();


        
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

    }
}
