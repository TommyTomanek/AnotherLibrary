namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public enum Genre
        {
            Akcni,
            Komedie,
            Horror
        }

    }
}
