using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities;

public class Movie : BaseEntity
{
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
}
