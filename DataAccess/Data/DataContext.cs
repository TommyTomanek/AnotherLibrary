using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Book> Books { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Person> Persons { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Employe> Employes { get; set; }




        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Person>()
                .HasKey(at => new { at.Id });


            modelbuilder.Entity<Person>().HasDiscriminator<int>("PersonType").HasValue<Employe>(1).HasValue<Customer>(2);

            modelbuilder.Entity<Employe>().HasOne(x => x.Superior).WithMany(x => x.Inferiors).HasForeignKey(x => x.SuperiorId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);

        }
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }


    }
}
