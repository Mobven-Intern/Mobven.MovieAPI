using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Infrastructure.Data.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired(true).HasMaxLength(50);
    }
}