using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy.Models;

namespace pharmacy.Forms
{
    public class ApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public DataWrapper data { get; set; }
    }
}
