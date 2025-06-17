using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1.Models
{
    public class Author
    {
        public int AuthorID {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age {  get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
