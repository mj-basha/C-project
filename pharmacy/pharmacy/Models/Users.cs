using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Models
{
    public class Users
    {
       public int id {  get; set; }
       public string username { get; set; }
        public string password_hash { get; set; }
        public string role { get; set; }
        public int failed_attempts { get; set; }
        public DateTime last_attempt { get; set; }


    }

    
}
