using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Entities
{
    public class Bookshelf
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
