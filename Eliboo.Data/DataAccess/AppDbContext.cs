using Eliboo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eliboo.Data.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Bookshelf> Bookshelves { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Library> Libraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .HasMany(b => b.Users)
                .WithMany(u => u.Books)
                .UsingEntity(j => j.ToTable("my_list"));
        }
    }
}
