using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Data;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly DataContext _context;

        public LibraryController(DataContext context)
        {
            _context = context;
        }

        private static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Author = "Autor"
            }
        };

        private static List<Employe> Employes = new List<Employe>
        {
            new Employe
            {
                Id = 1,
                SuperiorId = 1,
                Name = "Employe",
                Surname = "Employe",
                Mail = "user@domain.eu",
                Mobile = "123456789",
                Address = "Address"
            }
        };

        private static List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Employe",
                Surname = "Employe",
                Mail = "user@domain.eu",
                Mobile = "123456789",
                Address = "Address",
                LoginName = "Login"
            }
        };

        [HttpGet("Books")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return Ok(Books);
        }

        [HttpGet("Books/{id}")]
        public async Task<ActionResult<Book>> GetOneBook(int id)
        {
            var book = Books.Find((h => h.Id == id));
            if (book == null)
            {
                return BadRequest("Book not found");
            }

            return Ok(book);
        }

        [HttpPut("Books")]
        public async Task<ActionResult<List<Book>>> AppendBook(Book request)
        {

            var book = Books.Find(h => h.Id == request.Id);
            if (book == null)
                return BadRequest("Book not found");
            book.Author = request.Author;
            return Ok(Books);
        }

        [HttpPost("Books")]
        public async Task<ActionResult<List<Book>>> PostBook(Book book)
        {
            Books.Add(book);
            return Ok(Books);
        }

        [HttpDelete("Books/{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var book = Books.Find(h => h.Id == id);
            if (book == null)
                return BadRequest("Book not Found");
            Books.Remove(book);
            return Ok(Books);
        }

        [HttpGet("Employes")]
        public async Task<ActionResult<List<Employe>>> GetAllEmployes()
        {
            return Ok(Employes);
        }

        [HttpGet("Employes/{id}")]
        public async Task<ActionResult<Employe>> GetOneEmploye(int id)
        {
            var employe = Employes.Find(h => h.Id == id);
            if (Employes == null)
            {
                return BadRequest("Employe not found");
            }
            return Ok(employe);
        }

        [HttpPut("Employes")]
        public async Task<ActionResult<List<Employe>>> AppendEmploye(Employe request)
        {
            var employe = Employes.Find(h => h.Id == request.Id);
            if (employe == null)
                return BadRequest("Employe not found");
            employe.Name = request.Name;
            employe.Surname = request.Surname;
            employe.Mail = request.Mail;
            employe.Mobile = request.Mobile;
            employe.Address = request.Address;

            return Ok(Employes);
        }

        [HttpPost("Employes")]
        public async Task<ActionResult<List<Employe>>> AddEmploye(Employe request)
        {
            Employes.Add(request);
            return Ok(Employes);
        }

        [HttpDelete("Employes/{id}")]
        public async Task<ActionResult<List<Employe>>> DeleteEmploye(int id)
        {
            var employe = Employes.Find(h => h.Id == id);
            if (employe == null)
                return BadRequest("Employe not Found");
            Employes.Remove(employe);
            return Ok(Employes);
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return Ok(Customers);
        }

        [HttpGet("Customers/{id}")]
        public async Task<ActionResult<Customer>> GetOneCustomer(int id)
        {
            var customer = Customers.Find(h => h.Id == id);
            if (customer == null)
            {
                return BadRequest("Customer not Found");
            }
            return Ok(customer);
        }

        [HttpPost("Customers")]
        public async Task<ActionResult<List<Employe>>> AddCustomer(Customer request)
        {
            Customers.Add(request);
            return Ok(Customers);
        }

        [HttpPut("Customers")]
        public async Task<ActionResult<List<Customer>>> AppendCustomer(Customer request)
        {
            var customer = Customers.Find(h => h.Id == request.Id);
            if (customer == null)
                return BadRequest("Customer not found");
            customer.Name = request.Name;
            customer.Surname = request.Surname;
            customer.Mail = request.Mail;
            customer.Mobile = request.Mobile;
            customer.Address = request.Address;
            customer.LoginName = request.LoginName;
            
            return Ok(Customers);
        }
        

        [HttpDelete("Customers/{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var customer = Customers.Find(h => h.Id == id);
            if (customer == null)
                return BadRequest("Customer not Found");
            Customers.Remove(customer);
            return Ok(Customers);
        }
        //*/
    }
}
