using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Models
{
    public class Customer
    {
      public int CustomerID {  get; set; }
      public string FullName { get; set; }
       public string Phone { get; set; }
       public string Address { get; set; }
       public DateTime RegistrationDate { get; set; }
    }
}
