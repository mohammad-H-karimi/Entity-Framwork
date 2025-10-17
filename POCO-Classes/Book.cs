using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }         
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
