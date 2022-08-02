using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;

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
