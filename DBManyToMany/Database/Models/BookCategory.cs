namespace DBManyToMany.Database.Models
{
    public class BookCategory // Many to many jungiamoji lentele
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public Book Book { get; set; }
        public Category Category { get; set; }
    }
}
