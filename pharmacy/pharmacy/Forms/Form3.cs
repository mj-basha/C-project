using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using System.IO;
using pharmacy.DAL;
using pharmacy.Models;

namespace pharmacy
{
    public partial class Form3 : Form
    {
        private readonly string id;
        private readonly string username;
        private List<(Medicine medicine, int quantity)> cart = new List<(Medicine, int)>();


        private CustomerDAL customerDAL = new CustomerDAL();
        private InvoiceDAL invoiceDAL = new InvoiceDAL();
        private InvoiceDetailDAL invoiceDetailDAL = new InvoiceDetailDAL();
        public Form3(string id,string username)
        {
            InitializeComponent();
            this.id = id;
            this.username = username;
            
            comboBox1.Items.AddRange(new[] { "chick", "cash", "card" });


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "ادخل اسم العميل");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "ادخل رقم هاتف العميل");
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "ادخل عنوان العميل");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                errorProvider1.SetError(comboBox1, "ادخل حالة الدفع");
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }

            var cust = new Customer
                {
                    FullName = textBox1.Text.Trim(),
                    Phone = textBox2.Text.Trim(),
                    Address = textBox3.Text.Trim(),
                    RegistrationDate = DateTime.Now
                };
             customerDAL.AddCustomer(cust);
            ActivityLogger.Log("add customer", "تم اضافة عميل بنجاح", id, username);


            var inv = new Invoice
            {
                InvoiceDate = DateTime.Now,
                CustomerID = CustomerDAL.getid(textBox1.Text.Trim()),
                TotalAmount = decimal.Parse(textBox4.Text),
                PaymentStatus = comboBox1.Text
            };
            invoiceDAL.AddInvoiceWithID(inv);
            ActivityLogger.Log("add invoice", "تم اضافة فاتورة بنجاح", id, username);

            List<string> medicineDetails = new List<string>();

            foreach (var (medicine, qty) in cart)
            {
                int medId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MedicineID"].Value);
                var detail = new InvoiceDetail
                {
                    InvoiceID = InvoiceDAL.GetID(CustomerDAL.getid(textBox1.Text.Trim())),
                    MedicineID = medicine.MedicineID,
                    Quantity = qty,
                    UnitPrice = medicine.UnitPrice
                };
                invoiceDetailDAL.AddInvoiceDetail(detail);
                ActivityLogger.Log("add invoceDetails", "تم اضافة بيانات فاتورة بنجاح", id, username);
                QuantityDAL.decrease(MedicineDAL.getqid(medId),qty);
                medicineDetails.Add($"- {medicine.Name} | Qty: {qty} | Price: {medicine.UnitPrice:C}");
            }


            string message = $"Customer Details:\n" +
                  $"Name: {cust.FullName}\n" +
                  $"Phone: {cust.Phone}\n" +
                  $"Address: {cust.Address}\n\n" +
                  $"Invoice Details:\n" +
                  $"Date: {inv.InvoiceDate}\n" +
                  $"Total: {inv.TotalAmount:C}\n" +
                  $"Status: {inv.PaymentStatus}\n\n" +
                  $"Items:\n{string.Join("\n", medicineDetails)}";

            MessageBox.Show(message, "Invoice Summary");
            string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Invoice.pdf");

            
            InvoiceDAL.CreateInvoicePdf(pdfPath, message);


            ClearForm();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string searchTerm = textBox5.Text.Trim();
            DataTable dt = MedicineDAL.SearchByName(searchTerm);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
                var value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value != null)
                {
                    listBox1.Items.Add(value.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int medId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MedicineID"].Value);
            string name = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            decimal price = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["UnitPrice"].Value);
            int qty = (int)numericUpDown1.Value;

            var med = new Medicine { MedicineID = medId, Name = name, UnitPrice = price };

            cart.Add((med, qty));
            listBox1.Items.Add($"{name} × {qty}");
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            decimal total = cart.Sum(item => item.medicine.UnitPrice * item.quantity);
            textBox4.Text = total.ToString("F2");
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            dataGridView1.DataSource = null;
            listBox1.Items.Clear();
            cart.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 1;
            comboBox1.SelectedIndex = -1;
        }
    }
}
