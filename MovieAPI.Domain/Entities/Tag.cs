namespace MovieAPI.Domain.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Movie> Movies { get; set; }
}
