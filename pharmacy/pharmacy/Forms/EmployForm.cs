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

namespace pharmacy.Forms
{
    public partial class EmployForm : Form
    {
        string connectionString = @"Server=DESKTOP-627OQ7U\SQLEXPRESS;Database=PharmaDB;Trusted_Connection=True;";
        private readonly int id;
        private readonly string username;
        public EmployForm(int id,string username)
        {
            InitializeComponent();
            this.id = id;
            this.username = username;
            comboBox1.Items.AddRange(new[] { "Pharmesest", "StorageRoom" });
            comboBox2.Items.AddRange(new[] { "Training", "half time", "Full time" });
            LoadEmployeeIDs();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string n = textBox1.Text.Trim();
            string j = comboBox1.Text.Trim();
            string s = comboBox2.Text.Trim();

            if (string.IsNullOrEmpty(n))
            {
                errorProvider1.SetError(textBox1,"اكتب اسم الموظف");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            if (string.IsNullOrEmpty(j))
            {
                errorProvider1.SetError(comboBox1, "اختر الوظيفة");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }
            if (string.IsNullOrEmpty(s))
            {
                errorProvider1.SetError(comboBox2, "اختر حالة التوظيف");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }

            Employee employee = new Employee();
            employee.FullName = n;
            employee.JobTitle = j;
            employee.EmploymentStatus = s;

            EmployeeDAL.AddEmployee(employee);
            ActivityLogger.Log("Add employee", "تم اضافة موظف بنجاح", id, username);
            Ref();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string n = comboBox3.Text;


            if (string.IsNullOrEmpty(n))
            {
                errorProvider1.SetError(comboBox3, "اختر رقم الموظف");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox3, "");
            }

            EmployeeDAL.DeleteEmployee(Convert.ToInt32(n));
            ActivityLogger.Log("Delete medicine", "تم مسح موظف بنجاح", id, username);
            Ref();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string n = textBox1.Text.Trim();
            string s = comboBox2.Text;

            if (string.IsNullOrEmpty(n))
            {
                errorProvider1.SetError(textBox1, "اكتب اسم الموظف");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }

            if (string.IsNullOrEmpty(s))
            {
                errorProvider1.SetError(comboBox2, "اختر حالة التوظيف");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox2, "");
            }

            EmployeeDAL.UpdatStatus(n, s);
            ActivityLogger.Log("Update EmployeeStatus", "تم تعديل حالة التوظيف بنجاح", id, username);
            Ref();
        }

        public void Ref()
        {
            var dt = EmployeeDAL.GetAllEmployees();
            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string n = comboBox3.Text;

            if (string.IsNullOrEmpty(n))
            {
                errorProvider1.SetError(comboBox3, "اختر رقم الموظف");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox3, "");
            }
            var dt = EmployeeDAL.SearchEmployee(Convert.ToInt32(n));
            dataGridView1.DataSource = dt;
            ActivityLogger.Log("ٍSearch Employee", "تم البحث عن موظف بنجاح", id, username);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Ref();
            ActivityLogger.Log("list employees", "تم عرض كل الموظفين بنجاح", id, username);
        }

        private void LoadEmployeeIDs()
        {
            string query = "SELECT EmployeeID FROM Employees";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader["EmployeeID"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Employees IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
