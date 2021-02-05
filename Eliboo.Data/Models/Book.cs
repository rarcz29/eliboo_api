using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Author { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre { get; set; }

        [Required]
        public Bookshelf Bookshelf { get; set; }
    }
}
