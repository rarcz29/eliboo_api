using Eliboo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eliboo.Infrastructure.DataAccess.Configurations
{
    class BookshelfConfiguration : IEntityTypeConfiguration<Bookshelf>
    {
        public void Configure(EntityTypeBuilder<Bookshelf> builder)
        {
            builder.Property(b => b.LibraryId)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasIndex(b => new { b.LibraryId, b.Description })
                .IsUnique();
        }
    }
}
