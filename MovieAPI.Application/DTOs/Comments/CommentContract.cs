namespace MovieAPI.Application.DTOs;

public class CommentContract : IBaseContract
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Username { get; set; }
    public string MovieName { get; set; }
}
