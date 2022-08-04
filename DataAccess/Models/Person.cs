using Swashbuckle.AspNetCore.Annotations;

namespace Library.Models
{
    public abstract class Person
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

    }
}
