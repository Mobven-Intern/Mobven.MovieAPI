namespace MovieAPI.Application.DTOs;

public class RateContract : IBaseContract
{
    public int Id { get; set; }
    public float Rating { get; set; }
}
