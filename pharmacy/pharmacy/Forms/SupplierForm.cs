using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.DAL;
using pharmacy.Models;

namespace pharmacy.Forms
{
    public partial class SupplierForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-627OQ7U\SQLEXPRESS;Initial Catalog=PharmaDB;Integrated Security=True";
        private readonly int id;
        private readonly string username;
        public SupplierForm(int id, string username)
        {
            InitializeComponent();
            LoadSupplierIDs();
            this.id = id;
            this.username = username;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text.Trim();
            string p = textBox2.Text.Trim();
            string em = textBox3.Text.Trim();
            string a = textBox4.Text.Trim();
            string c = textBox5.Text.Trim();
            

            if (string.IsNullOrEmpty(s))
            {
                errorProvider1.SetError(textBox1,"اكتب اسم المورد");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            if (string.IsNullOrEmpty(p))
            {
                errorProvider1.SetError(textBox2, "اكتب رقم هاتف المورد");
               
                return;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
            if (string.IsNullOrEmpty(em))
            {
                errorProvider1.SetError(textBox3, "اكتب البريد الالكتروني");
                
                return;
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
            if (string.IsNullOrEmpty(a))
            {
                errorProvider1.SetError(textBox4, "اكتب العنوان");
                return ;
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
            if (string.IsNullOrEmpty(c))
            {
                errorProvider1.SetError(textBox5, "اكتب  اسم الشركة");
               
                return;
            }
            else
            {
                errorProvider1.SetError(textBox5, "");
            }

            Supplier supplier = new Supplier();
            supplier.Name = s;
            supplier.Phone = p;
            supplier.Email = em;
            supplier.Address = a;
            supplier.CompanyName = c;

            SupplierDAL.AddSupplier(supplier);
            ActivityLogger.Log("Add Supplier", "تم اضافة مورد بنجاح", id, username);
            Ref();

        }

        public void Ref()
        {
            var dt = SupplierDAL.GetAllSuppliers();
            dataGridView1.DataSource = dt;
        }

        private void btnListSupp_Click(object sender, EventArgs e)
        {
            Ref();
            ActivityLogger.Log("list all suppliers", "تم عرض جميع الموردين بنجاح", id, username);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            int d = Convert.ToInt32(comboBox1.Text);

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                errorProvider1.SetError(comboBox1, "اختر رقم المورد");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }

            var dt = SupplierDAL.Search(d);
            ActivityLogger.Log("ٍSearch Supplier", "تم البحث عن مورد بنجاح", id, username);
            dataGridView1.DataSource = dt;

        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            string d = comboBox1.Text;

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                errorProvider1.SetError(comboBox1, "اختر رقم المورد");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }

            SupplierDAL.DeleteSupplier(Convert.ToInt32(d));
            ActivityLogger.Log("Delete medicine", "تم مسح دواء بنجاح", id, username);
            Ref();
        }

        private void LoadSupplierIDs()
        {
            string query = "SELECT SupplierID FROM Suppliers";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["SupplierID"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Supplier IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
