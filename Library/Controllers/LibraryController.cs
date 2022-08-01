using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("Books")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return Ok(await _context.Books.ToListAsync());
            //return Ok(Books);
        }

        [HttpGet("Books/{id}")]
        public async Task<ActionResult<Book>> GetOneBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return BadRequest("Book not found");
            }

            return Ok(book);
        }

        [HttpPut("Books")]
        public async Task<ActionResult<List<Book>>> AppendBook(Book request)
        {

            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
                return BadRequest("Book not found");
            book.Author = request.Author;

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPost("Books")]
        public async Task<ActionResult<List<Book>>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("Books/{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not Found");
            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("Employes")]
        public async Task<ActionResult<List<Employe>>> GetAllEmployes()
        {
            return Ok(await _context.Employes.ToListAsync());
        }

        [HttpGet("Employes/{id}")]
        public async Task<ActionResult<Employe>> GetOneEmploye(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            if (_context.Employes == null)
            {
                return BadRequest("Employe not found");
            }
            return Ok(employe);
        }

        [HttpPut("Employes")]
        public async Task<ActionResult<List<Employe>>> AppendEmploye(Employe request)
        {
            var employe = await _context.Employes.FindAsync(request.Id);
            if (employe == null)
                return BadRequest("Employe not found");
            employe.Name = request.Name;
            employe.Surname = request.Surname;
            employe.Mail = request.Mail;
            employe.Mobile = request.Mobile;
            employe.Address = request.Address;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employes.ToListAsync());
        }

        [HttpPost("Employes")]
        public async Task<ActionResult<List<Employe>>> AddEmploye(Employe request)
        {
            _context.Employes.Add(request);

            await _context.SaveChangesAsync();

            return Ok(await _context.Employes.ToListAsync());
        }

        [HttpDelete("Employes/{id}")]
        public async Task<ActionResult<List<Employe>>> DeleteEmploye(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            if (employe == null)
                return BadRequest("Employe not Found");
            _context.Employes.Remove(employe);

            await _context.SaveChangesAsync();

            return Ok(await _context.Employes.ToListAsync());
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("Customers/{id}")]
        public async Task<ActionResult<Customer>> GetOneCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return BadRequest("Customer not Found");
            }
            return Ok(customer);
        }

        [HttpPost("Customers")]
        public async Task<ActionResult<List<Employe>>> AddCustomer(Customer request)
        {
            _context.Customers.Add(request);

            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpPut("Customers")]
        public async Task<ActionResult<List<Customer>>> AppendCustomer(Customer request)
        {
            var customer = await _context.Customers.FindAsync(request.Id);
            if (customer == null)
                return BadRequest("Customer not found");
            customer.Name = request.Name;
            customer.Surname = request.Surname;
            customer.Mail = request.Mail;
            customer.Mobile = request.Mobile;
            customer.Address = request.Address;
            customer.LoginName = request.LoginName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }


        [HttpDelete("Customers/{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return BadRequest("Customer not Found");

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }
        //*/
    }
}
