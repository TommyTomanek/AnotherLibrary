using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

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
    }
}
