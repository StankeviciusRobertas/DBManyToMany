using System.ComponentModel.DataAnnotations;

namespace DBManyToMany.Database.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<BookCategory> BookCategories { get; set; }
    }
}
