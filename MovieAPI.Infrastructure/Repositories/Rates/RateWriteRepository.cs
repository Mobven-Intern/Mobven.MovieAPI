using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Repositories.Rates
{
    public class RateWriteRepository : GenericRepository<Rate>, IRateWriteRepository
    {
        public RateWriteRepository(MovieAPIDbContext context) : base(context)
        {
        }
    }
}
