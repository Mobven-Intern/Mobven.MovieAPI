﻿namespace MovieAPI.Application.DTOs;

public class TagContract : IBaseContract
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> MovieList { get; set; }
}
