using DBManyToMany.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManyToMany.Database
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); galima istrinti

            //cia mes konfiguruojame sarysi many to many
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId }); // sujungta su dviem raktais
            
            modelBuilder.Entity<BookCategory>() //joininam lenteles
                .HasOne(bc => bc.Book) // book jungiam prie kategorijos
                .WithMany(b => b.BookCategories) // prie bendros lentos jungiam book
                .HasForeignKey(bc => bc.BookId);// pagal book id

            modelBuilder.Entity<BookCategory>() // join lentas
                .HasOne(bc => bc.Category) //categorija joininam prie kategorijos
                .WithMany(c => c.BookCategories) // prie bendros lentos jungiam kategorija
                .HasForeignKey(bc => bc.CategoryId); // pagal kategorijos id
        }
    }
}
