namespace Eliboo.Api.Contracts.Requests
{
    public class BookDataRequest
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string Bookshelf { get; set; }
    }
}
