using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Models
{
    public class Bookshelf
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
