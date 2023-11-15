using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManyToMany.Database.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; } // kompozicija i lentele Books
    }
}
