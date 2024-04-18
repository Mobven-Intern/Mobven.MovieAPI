using MovieAPI.Domain.Entities.Common;

namespace MovieAPI.Domain.Entities;

public class Rate : BaseEntity
{
    public float Rating { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
