using System.Collections.Generic;

namespace Eliboo.Domain.Entities
{
    public class Library
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Bookshelf> Bookshelves { get; set; }
    }
}
