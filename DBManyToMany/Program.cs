using DBManyToMany.Database;
using DBManyToMany.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DBManyToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Many to Many!");
            var dbContext = new BookContext(new DbContextOptionsBuilder<BookContext>()
                .UseSqlServer($"Server=localhost;Database=Books;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var robert = new Author { LastName = "Robertavicius" };
            var petras = new Author { LastName = "Petravicius" };
            var povilas = new Author { LastName = "Povilavicius" };
            var antanas = new Author { LastName = "Antanavicius" };

            dbContext.Authors.AddRange(robert, petras, povilas, antanas);
            dbContext.SaveChanges();

            var hobbit = new Book { Title = "The Hobbit", Year = 1937, Author = robert };
            var lordOfTheRings = new Book { Title = "The Lord of the Rings", Year = 1954, Author = robert };
            var silmarillion = new Book { Title = "The Silmarillion", Year = 1977, Author = robert };
            var hitchhikersGuide = new Book { Title = "The Hitchhikers's Guide to the Galaxy", Year = 1979, Author = petras };
            var dune = new Book { Title = "Dune", Year = 1965, Author = povilas };
            var endersGame = new Book { Title = "Ender's Game", Year = 1985, Author = antanas };


            dbContext.Books.AddRange(hobbit, lordOfTheRings, silmarillion, hitchhikersGuide, dune, endersGame);
            dbContext.SaveChanges();

            var catAdventure = new Category { CategoryName = "Adventure" };
            var catScience = new Category { CategoryName = "Science Fiction" };

            dbContext.Categories.AddRange(catAdventure, catScience);
            dbContext.SaveChanges();

            dbContext.BookCategories.Add(new BookCategory { Category = catAdventure, Book = hobbit });
            dbContext.BookCategories.Add(new BookCategory { Category = catAdventure, Book = lordOfTheRings });
            dbContext.BookCategories.Add(new BookCategory { Category = catAdventure, Book = silmarillion });

            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = hitchhikersGuide });
            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = dune });
            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = endersGame });
            dbContext.BookCategories.Add(new BookCategory { Category = catScience, Book = hobbit });
            dbContext.SaveChanges();
        }
    }
}