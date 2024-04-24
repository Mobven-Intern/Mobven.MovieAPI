﻿using AutoMapper;
using MovieAPI.Application.Interfaces;
using MovieAPI.Domain;
using MovieAPI.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Services
{
    public class BaseService<TEntity, TContract> : IBaseService<TContract>
        where TContract : class
        where TEntity : class, IBaseEntity
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(TContract model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _repository.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TContract> datas)
        {
            var list = _mapper.Map<List<TEntity>>(datas);
            var result = await _repository.AddRangeAsync(list);
        }

        public async Task<List<TContract>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<TContract>>(list);
        }

        public async Task<TContract> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<TContract>(result);
        }

        public async Task RemoveAsync(TContract model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await (_repository.RemoveAsync(entity));
            
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _repository.RemoveByIdAsync(id);
            
        }

        public async Task RemoveRangeAsync(List<TContract> datas)
        {
            var list = _mapper.Map<List<TEntity>>(datas);
            var result = await _repository.RemoveRangeAsync(list);
        }

        public async Task UpdateAsync(TContract model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _repository.UpdateAsync(entity);
        }
    }
}
