using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;


namespace Library.Data
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Book> Books { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Person> Persons { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }




        public void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Person>()
                .HasKey(at => new { at.Id });

           // modelbuilder.Entity<Employe>().HasMany(x => x.IdSuperior)
            /*
            builder.Entity<MenuItemBase>(eb =>
            {
                eb.HasIndex(x => x.DomainId);
                eb.HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
                eb.SetupMultiLanguage(x => x.Name, 200);
                eb
                    .HasDiscriminator<int>("_ModelType")
                    .HasValue<MenuItemStructure>(1)
                    .HasValue<MenuItemProcess>(2);
                builder.Entity<MenuItemStructure>().Property(x => x.Icon).HasMaxLength(35).IsUnicode(false);
            });
            */


            modelbuilder.Entity<Person>()
                .Map<Employe>(m => m.Requires("PersonType").HasValue(1))
                .Map<Customer>(m => m.Requires("PersonType").HasValue(2));     
                
        }

        private static readonly object context;
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }


    }
}
