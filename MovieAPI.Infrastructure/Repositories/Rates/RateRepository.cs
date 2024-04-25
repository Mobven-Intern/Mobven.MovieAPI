using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;

namespace MovieAPI.Infrastructure.Repositories;

public class RateRepository : GenericRepository<Rate>, IRateRepository
{
    public RateRepository(MovieAPIDbContext context) : base(context)
    {
    }
}
