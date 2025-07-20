using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.Models
{
    public class InvoiceDetail
    {
       public int InvoiceDetailID {  get; set; }
       public int InvoiceID {  get; set; }
       public int MedicineID {  get; set; }
       public int Quantity {  get; set; }
       public decimal UnitPrice {  get; set; }
    }
}
