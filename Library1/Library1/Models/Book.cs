using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class Book
    {
        public int BookID {  get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int PublicationYear { get; set; }

        public Author Author { get; set; }
    }
}
