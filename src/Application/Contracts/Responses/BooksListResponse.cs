using System.Collections.Generic;

namespace Eliboo.Api.Contracts.Responses
{
    public class BooksListResponse
    {
        public IEnumerable<BookResponse> Books { get; set; }
    }
}
