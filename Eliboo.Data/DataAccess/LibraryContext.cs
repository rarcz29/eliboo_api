using Eliboo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eliboo.Data.DataAccess
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Bookshelf> Bookshelves { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<MyList> MyList { get; set; }

        public DbSet<ReadingNow> ReadingNow { get; set; }
    }
}
