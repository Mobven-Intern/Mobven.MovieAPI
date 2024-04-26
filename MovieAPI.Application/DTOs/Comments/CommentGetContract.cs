namespace MovieAPI.Application.DTOs;

public class CommentGetContract
{
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public string MovieName { get; set; }
    public string Username { get; set; }
}
