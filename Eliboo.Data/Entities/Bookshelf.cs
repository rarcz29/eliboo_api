using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Entities
{
    public class Bookshelf
    {
        public int Id { get; set; }

        [Required]
        public int LibraryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public Library Library { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
