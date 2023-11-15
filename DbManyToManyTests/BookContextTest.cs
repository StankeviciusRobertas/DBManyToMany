using DBManyToMany.Database;
using DBManyToMany.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DbManyToManyTests
{
    [TestClass]
    public class BookContextTest
    {
        private BookContext dbContext;

        [TestInitialize]
        public void OnInit()
        {
            dbContext = new BookContext(new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "BookContext" + Guid.NewGuid())
                .Options);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var tolkien = new Author { LastName = "Tolkien" };
            var adams = new Author { LastName = "Adams" };
            var herbert = new Author { LastName = "Herbert" };
            var card = new Author { LastName = "Card" };

            dbContext.Authors.AddRange(tolkien, adams, herbert, card);
            dbContext.SaveChanges();

            var hobbit = new Book { Title = "The Hobbit", Year = 1937, Author = tolkien };
            var lordOfTheRings = new Book { Title = "The Lord of the Rings", Year = 1954, Author = tolkien };
            var silmarillion = new Book { Title = "The Silmarillion", Year = 1977, Author = tolkien };
            var hitchhikersGuide = new Book { Title = "The Hitchhikers's Guide to the Galaxy", Year = 1979, Author = adams };
            var dune = new Book { Title = "Dune", Year = 1965, Author = herbert };
            var endersGame = new Book { Title = "Ender's Game", Year = 1985, Author = card };

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

            Assert.AreEqual(4, dbContext.Authors.Count());
            Assert.AreEqual(6, dbContext.Books.Count());
            Assert.AreEqual(2, dbContext.Categories.Count());
            Assert.AreEqual(7, dbContext.BookCategories.Count());
        }
    }
}