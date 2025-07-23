using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pharmacy.Models
{
    public class Medicine
    {
       public int MedicineID {  get; set; }
        public int SupplierID { get; set; }
        public string Name {  get; set; }
       public string Manufacturer {  get; set; }
       public string Category {  get; set; }
       public int quantityID {  get; set; }
        public decimal UnitPrice {  get; set; }
        
    }
}
