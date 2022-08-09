using Library.Models;

namespace Library
{
    public class BookResponse
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
