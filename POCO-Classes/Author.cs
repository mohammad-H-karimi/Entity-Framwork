using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; } 
        public DateTime BirthdayDate { get; set; }
        public string Nationality { get; set; }
        public string Biography { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
