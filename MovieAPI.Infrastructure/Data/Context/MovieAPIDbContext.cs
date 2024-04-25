using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.Data.Configurations;

namespace MovieAPI.Infrastructure.Data.Context;

public class MovieAPIDbContext : DbContext
{
    public MovieAPIDbContext() { }
    public MovieAPIDbContext(DbContextOptions options) : base(options) { }


    /// <summary>
    /// Sb sets added
    /// Db table configurations applied
    /// </summary>
    /// <param name="modelBuilder"></param>

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Rate> Rates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new RateConfiguration());

        base.OnModelCreating(modelBuilder);

    }

}
