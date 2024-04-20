using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.Id).IsRequired(true).ValueGeneratedOnAdd();
        builder.HasKey(e => e.Id);

        builder.Property(e => e.FirstName).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.LastName).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Username).IsRequired(true).HasMaxLength(50);
        builder.HasIndex(e => e.Username).IsUnique(true);
        builder.Property(e => e.Password).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Email).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.BirthDate).IsRequired(true).HasMaxLength(50);
        builder.Property(e => e.Role).IsRequired(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.LastLogin).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.CreatedOn).HasDefaultValueSql("getdate()").HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.UpdatedOn).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        builder.Property(e => e.DeletedOn).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}
