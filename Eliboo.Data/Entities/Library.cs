using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Entities
{
    public class Library
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string AccessToken { get; set; }

        public IEnumerable<User> Users { get; set; }

        public IEnumerable<Bookshelf> Bookshelves { get; set; }
    }
}
