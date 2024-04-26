namespace MovieAPI.Application.DTOs;

public class MovieUpdateContract : IBaseContract
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string ImagePath { get; set; }

    public List<int> GenreList { get; set; }
    public List<int> TagList { get; set; }
}
