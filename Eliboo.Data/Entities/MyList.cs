using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Entities
{
    [Keyless]
    public class MyList
    {
        [Required]
        public User Users { get; set; }

        [Required]
        public Book Books { get; set; }
    }
}
