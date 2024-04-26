namespace MovieAPI.Application.DTOs;

public class MovieGetAllContract
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ReleaseYear { get; set; }
    public string ImagePath { get; set; }

    public List<string> GenreList { get; set; }
    public List<string> TagList { get; set; }
    public float AverageRate { get; set; }
}
