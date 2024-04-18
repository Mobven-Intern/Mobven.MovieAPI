using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities;

public class Comment : BaseEntity
{
    public string Description { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime DeletedOn { get; set; }
}
