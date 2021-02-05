using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        public Bookshelf Bookshelf { get; set; }
    }
}
