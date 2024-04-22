using MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Repositories
{
    public interface IMovieWriteRepository: IGenericRepository<Movie>
    {
    }
}
