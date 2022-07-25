using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

    }
}
