using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities.Abstracts;

namespace MovieAPI.Domain.Repositories;

public interface IGenericRepository<T> where T : class, IBaseEntity
{
    DbSet<T> Table { get; }

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
