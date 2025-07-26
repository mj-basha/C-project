using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pharmacy.Models
{
    public class Employee
    {
       public int EmployeeID {  get; set; }
       public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string EmploymentStatus { get; set; }
    }
}
