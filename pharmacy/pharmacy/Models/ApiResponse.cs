using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Forms
{
    public class ApiResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<UserMessage> data { get; set; }
    }
}
