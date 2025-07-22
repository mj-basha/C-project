using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Models
{
    public class Filters
    {
        public string system_id { get; set; }
        public object is_read { get; set; }
        public object user_id { get; set; }
    }
}
