using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        private CancellationToken cancellationToken;

        public CustomerController(DataContext context)
        {
            _context = context;
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

        [HttpGet("Customers/SortCustomers")]
        public async Task<ActionResult<List<Customer>>> GetAscOrderedCustomers(string filter, string key)
        {
            if (filter == "ID")
            {
                var Sorted = await _context.Customers.Where(x => x.Id.CompareTo(key) == 0).OrderBy(x => x.Id).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Name")
            {
                var Sorted = await _context.Customers.Where(x => x.Name.Contains(key)).OrderBy(x => x.Name).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Surname")
            {
                var Sorted = await _context.Customers.Where(x => x.Surname.Contains(key)).OrderBy(x => x.Surname).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Mail")
            {
                var Sorted = await _context.Customers.Where(x => x.Mail.Contains(key)).OrderBy(x => x.Mail).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Mobile")
            {
                var Sorted = await _context.Customers.Where(x => x.Mobile.Contains(key)).OrderBy(x => x.Mobile).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Address")
            {
                var Sorted = await _context.Customers.Where(x => x.Address.Contains(key)).OrderBy(x => x.Address).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Login")
            {
                var Sorted = await _context.Customers.Where(x => x.LoginName.Contains(key)).OrderBy(x => x.LoginName).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else
            {
                return BadRequest("Error " +
                    "Options for filter: ID, " +
                    "Name, " +
                    "Surname, " +
                    "Mail, " +
                    "Address, " +
                    "Login, " +
                    "Mobile");
            }
        }

        [HttpGet("Customer/GroupCustomers")]
        public async Task<ActionResult<List<Customer>>> GetGroupedCustomers(string GroupSelection)
        {

            if (GroupSelection == "ID")
            {
                var grouped = await _context.Customers
                    .GroupBy(x => x.Id)
                    .Select(x => new { Id = x.Key, SameIdCount = x.Count()})
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Name")
            {
                var grouped = await _context.Customers
                    .GroupBy(x => x.Name)
                    .Select(x => new { Name = x.Key, SameNameCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Surname")
            {
                var grouped = await _context.Customers
                        .GroupBy(x => x.Surname)
                        .Select(x => new { Surname = x.Key, SameSurnameCount = x.Count() })
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Mail")
            {
                var grouped = await _context.Customers
                    .GroupBy(x => x.Mail)
                    .Select(x => new { Mail = x.Key, SameMailCount = x.Count()})
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Mobile")
            {
                var grouped = await _context.Customers
                    .GroupBy(x => x.Mobile)
                    .Select(x => new { Mobile = x.Key, SameMobileCount = x.Count()})
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Address")
            {
                var grouped = await _context.Customers
                    .GroupBy(x => x.Address)
                    .Select(x => new { Address = x.Key, SameAddressCount = x.Count()})
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Login")
            {
                var grouped = await _context.Customers
                    .GroupBy(x => x.LoginName)
                    .Select(x => new { LoginName = x.Key, SameLoginNameCount = x.Count()})
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else
            {
                return BadRequest("Error " +
                    "Options for filter: ID, " +
                    "Name, " +
                    "Surname, " +
                    "Mail, " +
                    "Address, " +
                    "Login, " +
                    "Mobile");
            }            
        }
        
        [HttpGet("Customer/Paging{page}")]
        public async Task<ActionResult<List<Customer>>> GetPagedCustomers(int page)
        {
            if (_context.Customers == null)
                return NotFound();

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Customers.Count() / pageResults);

            var customers = await _context.Customers
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new CustomerResponse
            {
                Customers = customers,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        [HttpPost("Customers")]
        public async Task<ActionResult<List<Employe>>> AddCustomer(Customer request)
        {
            _context.Customers.Add(request);

            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpPut("Customers/{id}")]
        public async Task<ActionResult<List<Customer>>> AppendCustomer(Customer request, int id)
        {
            var customer = await _context.Customers.FindAsync(id);
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
    }
}
