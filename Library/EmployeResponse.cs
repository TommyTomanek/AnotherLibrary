using Library.Models;


namespace Library
{
    public class EmployeResponse
    {
        public List<Employe> Employes { get; set; } = new List<Employe>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
