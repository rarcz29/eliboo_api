using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Models
{
    public class MyList
    {
        [Required]
        public User Users { get; set; }

        [Required]
        public Book Books { get; set; }
    }
}
