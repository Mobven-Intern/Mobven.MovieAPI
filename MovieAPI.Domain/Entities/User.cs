namespace MovieAPI.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string BirthDate { get; set; }
    public string Role { get; set; }
    public bool IsDeleted { get; set; }

    public DateTime LastLogin { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime DeletedOn { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Rate> Rates { get; set; }
}
