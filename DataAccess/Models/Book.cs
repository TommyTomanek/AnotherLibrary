//using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Swashbuckle.AspNetCore.Annotations;
//using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Book
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Author { get; set; }
        public Genre Genres { get; set; }

        public enum Genre 
        {
            Akcni = 1,
            Komedie = 2,
            Horror = 3
        }
    }
}
