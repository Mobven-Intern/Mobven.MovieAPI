﻿using MovieAPI.Domain.Entities.Abstracts;

namespace MovieAPI.Application.Interfaces;

public interface IBaseService<TEntity, TContract> 
    where TContract : class
    where TEntity : class, IBaseEntity
{
    Task AddAsync(TContract model);
    Task AddRangeAsync(List<TContract> datas);
    Task RemoveAsync(TContract model);
    Task RemoveRangeAsync(List<TContract> datas);
    Task RemoveByIdAsync(int id);
    Task UpdateAsync(TContract model);
    Task <List<TContract>> GetAllAsync();
    Task<TContract> GetByIdAsync(int id);
}
