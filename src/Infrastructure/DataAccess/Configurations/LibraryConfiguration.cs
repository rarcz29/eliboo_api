using Eliboo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eliboo.Infrastructure.DataAccess.Configurations
{
    class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.Property(l => l.AccessToken)
                .HasMaxLength(32)
                .IsRequired();

            builder
                .HasIndex(l => l.AccessToken)
                .IsUnique();
        }
    }
}
