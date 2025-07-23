using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy.Models;

namespace pharmacy.Data
{
    public static class GlobalData
    {
        public static List<Medicine> MedicinesList { get; private set; }
        public static List<Employee> EmployeesList { get; private set; }
        public static List<Customer> CustomersList { get; private set; }
        public static List<Invoice> InvoicesList { get; private set; }
        public static List<InvoiceDetail> InvoiceDetailsList { get; private set; }
        public static List<Quantity> QuantitysList { get; private set; }
        public static List<Supplier> SuppliersList { get; private set; }
        public static List<Users> UsersList { get; private set; }

    }
}
