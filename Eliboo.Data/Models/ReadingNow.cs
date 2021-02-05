using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Models
{
    public class ReadingNow
    {
        [Required]
        public User Users { get; set; }

        [Required]
        public Book Books { get; set; }
    }
}
