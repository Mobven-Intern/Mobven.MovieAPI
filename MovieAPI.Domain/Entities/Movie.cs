using MovieAPI.Domain.Entities.Abstracts;

namespace MovieAPI.Domain.Entities;

public class Movie : IBaseEntity, ISoftDelete
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }

    public string CreatedBy { get; set; }
    public string DeletedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime DeletedOn { get; set; }

    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Rate> Rates { get; set; }
}
