using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {        
        private readonly DataContext _context;
        private CancellationToken cancellationToken;

        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Books")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return Ok(await _context.Books.ToListAsync());
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
        
        [HttpPost("Books")]
        public async Task<ActionResult<List<Book>>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }
        //LinQ
        [HttpGet("Books/SortBooks")]
        public async Task<ActionResult<List<Book>>> GetAscOrderedBooks(string filter, string key)
        {
            if (filter == "Id")
            {
                var Sorted = await _context.Books.Where(x => x.Id.CompareTo(key) == 0).OrderBy(x => x.Id).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else if (filter == "Author")
            {
                var Sorted = await _context.Books.Where(x => x.Author.Contains(key)).OrderBy(x => x.Author).AsNoTracking().ToListAsync(cancellationToken);
                return Ok(Sorted);
            }
            else
            {
                return BadRequest("Error " +
                    "Options for filter: Id, " +
                    "Author");
            }
        }

        [HttpGet("Book/GroupBooks")]
        public async Task<ActionResult<List<Book>>> GetGroupedBooks(string GroupSelection)
        {

            if (GroupSelection == "Id")
            {
                var grouped = await _context.Books
                    .GroupBy(x => x.Id)
                    .Select(x => new { Id = x.Key, SameIdCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else if (GroupSelection == "Author")
            {
                var grouped = await _context.Books
                    .GroupBy(x => x.Author)
                    .Select(x => new { Author = x.Key, SameAuthorCount = x.Count() })
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return Ok(grouped);
            }
            else
            {
                return BadRequest("Error " +
                    "Options for filter: ID, " +
                    "Author");
            }
        }

        [HttpGet("Book/Paging{page}")]
        public async Task<ActionResult<List<Book>>> GetPagedBooks(int page)
        {
            if (_context.Books == null)
                return NotFound();

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Books.Count() / pageResults);

            var books = await _context.Books
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            var response = new BookResponse
            {
                Books = books,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            
            return Ok(response);
        }
        //--

        [HttpPut("Books/{id}")]
        public async Task<ActionResult<List<Book>>> AppendBook(Book request, int id)
        {

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found");
            book.Author = request.Author;

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
    }
}
