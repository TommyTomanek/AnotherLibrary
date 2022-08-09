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
        private CancellationToken cancellationToken;

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

        //LinQ
        [HttpGet("Employes/SortEmployes")]
        public async Task<ActionResult<List<Employe>>> GetAscOrderedEmployes(string filter, string key)
        {
            if (filter == "ID")
            {
                var Sorted = await _context.Employes.Where(x => x.Id.CompareTo(key) == 0).OrderBy(x => x.Id).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Name")
            {
                var Sorted = await _context.Employes.Where(x => x.Name.Contains(key)).OrderBy(x => x.Name).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Surname")
            {
                var Sorted = await _context.Employes.Where(x => x.Surname.Contains(key)).OrderBy(x => x.Surname).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Mail")
            {
                var Sorted = await _context.Employes.Where(x => x.Mail.Contains(key)).OrderBy(x => x.Mail).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Mobile")
            {
                var Sorted = await _context.Employes.Where(x => x.Mobile.Contains(key)).OrderBy(x => x.Mobile).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Address")
            {
                var Sorted = await _context.Employes.Where(x => x.Address.Contains(key)).OrderBy(x => x.Address).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Superior")
            {
                var Sorted = await _context.Employes
                    .Where(x => x.Superior.ToString().Contains(key))
                    .OrderBy(x => x.Superior.ToString())
                    .AsNoTracking()
                    .ToListAsync();
                //var Sorted = await _context.Employes.Where(x => x.Superior.Contains(key)).OrderBy(x => x.Superior).AsNoTracking().ToListAsync(cancellationToken);
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
                    "Mobile" +
                    "Superior");
            }
        }

        [HttpGet("Employe/GroupEmployes")]
        public async Task<ActionResult<List<Employe>>> GetGroupedEmployes(string GroupSelection)
        {

            if (GroupSelection == "ID")
            {
                var grouped = await _context.Employes
                    .GroupBy(x => x.Id)
                    .Select(x => new { Id = x.Key, SameIdCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Name")
            {
                var grouped = await _context.Employes
                    .GroupBy(x => x.Name)
                    .Select(x => new { Name = x.Key, SameNameCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Surname")
            {
                var grouped = await _context.Employes
                        .GroupBy(x => x.Surname)
                        .Select(x => new { Surname = x.Key, SameSurnameCount = x.Count() })
                        .AsNoTracking()
                        .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Mail")
            {
                var grouped = await _context.Employes
                    .GroupBy(x => x.Mail)
                    .Select(x => new { Mail = x.Key, SameMailCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Mobile")
            {
                var grouped = await _context.Employes
                    .GroupBy(x => x.Mobile)
                    .Select(x => new { Mobile = x.Key, SameMobileCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Address")
            {
                var grouped = await _context.Employes
                    .GroupBy(x => x.Address)
                    .Select(x => new { Address = x.Key, SameAddressCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Superior")
            {
                var grouped = await _context.Employes
                    .GroupBy(x => x.Superior)
                    .Select(x => new { Superior = x.Key, SameSuperiorNameCount = x.Count() })
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

        [HttpGet("Employe/Paging{page}")]
        public async Task<ActionResult<List<Employe>>> GetPagedEmployes(int page)
        {
            if (_context.Employes == null)
                return NotFound();

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Employes.Count() / pageResults);

            var employes = await _context.Employes
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new EmployeResponse
            {
                Employes = employes,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }
        //--

        [HttpPost("Employes")]
        public async Task<ActionResult<List<Employe>>> AddEmploye(Employe request)
        {
            _context.Employes.Add(request);

            await _context.SaveChangesAsync();

            return Ok(await _context.Employes.ToListAsync());
        }

        [HttpPut("Employes/{id}")]
        public async Task<ActionResult<List<Employe>>> AppendEmploye(Employe request, int id)
        {
            var employe = await _context.Employes.FindAsync(id);
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
