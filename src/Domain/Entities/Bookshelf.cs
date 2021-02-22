using System.Collections.Generic;

namespace Eliboo.Domain.Entities
{
    public class Bookshelf
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int LibraryId { get; set; }
        public Library Library { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
