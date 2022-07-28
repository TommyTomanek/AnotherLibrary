namespace Library.Models
{
    public class Employe : Person
    {
        /*
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        */
        public int SuperiorId { get; set; }

        public Employe Superior { get; set; }


        public List<Employe> Inferiors { get; set; }
    }
}
