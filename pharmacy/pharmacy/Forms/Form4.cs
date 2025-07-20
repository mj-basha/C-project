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
using System.Xml.Linq;
using pharmacy.DAL;
using pharmacy.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pharmacy
{
    public partial class Form4 : Form
    {
        private readonly string id;
        private readonly string username;

        string connectionString = @"Data Source=DESKTOP-627OQ7U\SQLEXPRESS;Initial Catalog=PharmaDB;Integrated Security=True";
        public Form4(string id,string username)
        {
            InitializeComponent();
            this.id=id;
            this.username=username;
            LoadSupplierIDs();
            LoadMedIDs();
            comboBox3.Items.AddRange(new[] { "Antibiotics", "Antivirals", "Antifungals", "Antihistamines", "Vaccines" });
        }

        private void button1_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            string n = textBox1.Text.Trim();
            string s = comboBox1.Text.Trim();
            
            Decimal p = Convert.ToDecimal(textBox4.Text.Trim());
            
            string c = comboBox3.Text.Trim();
            string m = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(n))
            {
                errorProvider1.SetError(textBox1,"اكتب اسم الدواء");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }

            if (string.IsNullOrEmpty(s))
            {
                errorProvider1.SetError(comboBox1,"أختر المورد");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
           
            if (string.IsNullOrEmpty(Convert.ToString(p)))
            {
                errorProvider1.SetError(textBox4,"اكتب السعر");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }
           
            if (string.IsNullOrEmpty(c))
            {
                errorProvider1.SetError(comboBox3,"اختر الصنف");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox3, "");
            }
            if (string.IsNullOrEmpty(m))
            {
                errorProvider1.SetError(textBox2,"اكتب اسم المصنع");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }

           

           

                Medicine medicine = new Medicine();
                medicine.Name = n;
                medicine.SupplierID = Convert.ToInt32(s);
                medicine.Manufacturer = m;
                medicine.Category = c;
                medicine.UnitPrice = p;
                medicine.quantityID = QuantityDAL.GetID(n);


                MedicineDAL.AddMedicine(medicine);
            
            Ref();
            ActivityLogger.Log("Add medicine", "تم اضافة دواء بنجاح", id, username);

        }

        public void Ref()
        {
            var dt = MedicineDAL.GetAllMedicines();
            dgvmed.DataSource = dt;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Ref();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = comboBox2.Text;

            if (string.IsNullOrEmpty(id))
            {
               
                errorProvider1.SetError(comboBox2, "اختر رقم الدواء");
                return;
            }


            MedicineDAL.DeleteMedicine(Convert.ToInt32(id));
            ActivityLogger.Log("Delete medicine", "تم مسح دواء بنجاح", id, username);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = comboBox2.Text;

            if (string.IsNullOrEmpty(id))
            {
                errorProvider1.SetError(comboBox2, "اختر رقم الدواء");
                return;
            }


            MedicineDAL.Search(Convert.ToInt32(id));
            ActivityLogger.Log("Search medicine", "تم البحث عن دواء بنجاح", id, username);
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

             private void LoadMedIDs()
        {
            string query = "SELECT MedicinesID FROM Medicines";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["MedicinesID"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Error loading Medicines IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int q = Convert.ToInt32(textBox3.Text.Trim());
            DateTime ed =dateTimePicker1.Value;
            string n = textBox1.Text.Trim();



            if (string.IsNullOrEmpty(n))
            {
                errorProvider1.SetError(textBox1, "اكتب اسم الدواء");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            if (string.IsNullOrEmpty(Convert.ToString(q)))
            {
                errorProvider1.SetError(textBox3, "اكتب الكمية");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }

            if (string.IsNullOrEmpty(Convert.ToString(ed)))
            {
                errorProvider1.SetError(dateTimePicker1, "اختر التاريخ");
                return;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker1, "");
            }

            Quantity qu = new Quantity();
            qu.quantityOF = q;
            qu.ExpiryDate = ed;
            qu.name = n;

             QuantityDAL.AddQuantity(qu);
            
        }
    }
}
