using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Infrastructure.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).IsRequired(true).HasMaxLength(250);
        builder.Property(e => e.CreatedOn).HasDefaultValueSql("getdate()").HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.UpdatedOn).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.DeletedOn).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
    }
}
