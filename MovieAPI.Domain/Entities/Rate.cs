using MovieAPI.Domain.Entities.Abstracts;

namespace MovieAPI.Domain.Entities;

public class Rate : IBaseEntity
{
    public int Id { get; set; }
    public float Rating { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}
