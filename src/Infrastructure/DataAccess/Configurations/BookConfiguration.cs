using Eliboo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eliboo.Infrastructure.DataAccess.Configurations
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasMany(b => b.Users)
                .WithMany(u => u.Books)
                .UsingEntity(j => j.ToTable("my_list"));

            builder
                .HasOne(b => b.User)
                .WithOne(u => u.CurrentReading)
                .HasForeignKey<User>(u => u.CurrentReadingId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(b => b.BookshelfId)
                .IsRequired();

            builder.Property(b => b.Title)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(b => b.Author)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(b => b.Author)
                .HasMaxLength(40);
        }
    }
}
