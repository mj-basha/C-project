using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Models
{
    public class Invoice
    {
       public int  InvoiceID {  get; set; }
       public DateTime InvoiceDate {  get; set; }
       public int CustomerID { get;  set; }
       public decimal TotalAmount { get;  set; }
       public string PaymentStatus { get; set; }
    }
}
