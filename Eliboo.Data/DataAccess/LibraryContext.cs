using Eliboo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eliboo.Data.DataAccess
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
