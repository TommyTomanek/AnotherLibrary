using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public enum Genre 
        {
            Akcni = 1,
            Komedie = 2,
            Horror = 3
        }

    }
}
