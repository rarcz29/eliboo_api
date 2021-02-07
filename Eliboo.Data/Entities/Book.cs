using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [MaxLength(40)]
        public string Author { get; set; }

        [MaxLength(30)]
        public string Genre { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
