


namespace Library.Models
{
    public class Employe : Person
    {
        public int SuperiorId { get; set; }
        public Employe Superior { get; set; }
        public List<Employe> Inferiors { get; set; }
    }
}
