﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy.Forms;

namespace pharmacy.Models
{
    public class MessageData
    {
        public int id { get; set; }
        public string name { get; set; }
        public int user_id { get; set; }
        public string phone { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
    }
}
