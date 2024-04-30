using MovieAPI.Domain.Entities.Abstracts;

namespace MovieAPI.Domain.Entities;

public class Comment : IBaseEntity
{
    public int Id { get; set; }
    public string Description { get; set; }

    public DateTime? CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}
