namespace MovieAPI.Application.Interfaces;

public interface IBaseService<TContract> where TContract : class
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
