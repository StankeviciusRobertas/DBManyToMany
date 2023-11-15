using System.ComponentModel.DataAnnotations;

namespace DBManyToMany.Database.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<BookCategory> BookCategories { get; set; }
        public Author Author { get; set; }
    }
}
