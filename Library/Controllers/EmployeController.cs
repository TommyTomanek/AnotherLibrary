using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeController(DataContext context)
        {
            _context = context;
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

        [HttpPost("Employes")]
        public async Task<ActionResult<List<Employe>>> AddEmploye(Employe request)
        {
            _context.Employes.Add(request);

            await _context.SaveChangesAsync();

            return Ok(await _context.Employes.ToListAsync());
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
            employe.Superior = request.Superior;
            employe.Inferiors = request.Inferiors;

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
    }
}
