using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eliboo.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public int LibraryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Library Library { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
