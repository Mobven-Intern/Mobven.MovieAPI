using MovieAPI.Domain.Entities.Abstracts;

namespace MovieAPI.Domain.Entities;

public class Tag : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Movie> Movies { get; set; }
}
