using System.Collections.Generic;

namespace Eliboo.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public int BookshelfId { get; set; }
        public Bookshelf Bookshelf { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
