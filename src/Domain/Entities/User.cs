using System;
using System.Collections.Generic;

namespace Eliboo.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public int LibraryId { get; set; }
        public Library Library { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
