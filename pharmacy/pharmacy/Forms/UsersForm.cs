using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.DAL;
using pharmacy.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pharmacy.Forms
{
    public partial class UsersForm : Form
    {

        string connectionString = @"Server=DESKTOP-627OQ7U\SQLEXPRESS;Database=PharmaDB;Trusted_Connection=True;";
        private readonly string id;
        private readonly string username;
        public UsersForm(string id,string username)
        {
            InitializeComponent();
            this.id=id;
            this.username=username;
            cmbRole.Items.AddRange(new[] { "admin", "editor", "viewer" });
            LoadUserIDs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = txtUsername.Text.Trim();
            var p = txtPassword.Text;
            var c = txtConfirm.Text;
            var r = cmbRole.Text;

            if (!Regex.IsMatch(u, @"^[A-Za-z][\w]{4,}$"))
            {
                errorProvider1.SetError(txtUsername,"اسم المستخدم يجب أن يبدأ بحرف ويكون 5+ أحرف");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
            if (!Regex.IsMatch(p, @"(?=.*\d)(?=.*\W).{8,}"))
            {
                errorProvider1.SetError(txtPassword, "كلمة المرور 8+ أحرف وتحتوي أرقام ورموز");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
            if (p != c)
            {
                errorProvider1.SetError(txtPassword, "كلمة المرور غير مطابقة");
                errorProvider1.SetError(txtConfirm, "كلمة المرور غير مطابقة");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
                errorProvider1.SetError(txtConfirm, "");
            }
            if (string.IsNullOrEmpty(r))
            {
                errorProvider1.SetError(cmbRole, "اختر دورًا للمستخدم");
                return;
            }
            else
            {
                errorProvider1.SetError(cmbRole, "");
            }
            if (UsersDAL.getname(u) > 0)
            {
                errorProvider1.SetError(cmbRole, "اسم المستخدم موجود مسبقا");
                return;
            }
            else
            {
                Users user = new Users();
                user.username = u;
                user.password_hash = p;
                user.role = r;

                UsersDAL.AddUser(user);
                ActivityLogger.Log("Add Users", "تم اضافة مستخدم بنجاح", id, username);
                Ref();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Ref();
        }

        public void Ref()
        {
            var dt = UsersDAL.GetAllUsers();
            dataGridView1.DataSource = dt;
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            string us= comboBox1.Text;

            if (string.IsNullOrEmpty(us)) 
            {
                errorProvider1.SetError(comboBox1, "اختر رقم للمستخدم");
                return;
            }
            else
            {
                errorProvider1.SetError(comboBox1, "");
            }

            UsersDAL.deleteUser(us);
            ActivityLogger.Log("Delete medicine", "تم مسح مستخدم بنجاح", id, username);
            Ref();
        }

        private void btnChan_Click(object sender, EventArgs e)
        {
            var us = txtUsername.Text.Trim();
            var pa = txtPassword.Text;
            var co = txtConfirm.Text;

            if (string.IsNullOrEmpty(us))
            {
                errorProvider1.SetError(txtUsername, "اكتب اسم المستخدم");
                return;
            }
            else if (us != null)
            {
                
                    errorProvider1.SetError(txtUsername, "");
                
            }


            else
            {

                if (!Regex.IsMatch(pa, @"(?=.*\d)(?=.*\W).{8,}"))
                {
                    errorProvider1.SetError(txtPassword, "كلمة المرور 8+ أحرف وتحتوي أرقام ورموز");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtPassword, "");
                }
                if (pa != co)
                {
                    errorProvider1.SetError(txtPassword, "كلمة المرور غير مطابقة");
                    errorProvider1.SetError(txtConfirm, "كلمة المرور غير مطابقة");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtPassword, "");
                    errorProvider1.SetError(txtConfirm, "");
                }

                UsersDAL.changepass(us, pa);
                ActivityLogger.Log("change Users password", "تم تغيير كلمة المرور بنجاح", id, username);
                Ref();

            }
            } 
             private void LoadUserIDs()
        {
            string query = "SELECT id FROM Users";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["id"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Users IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(comboBox1.Text);

            UsersDAL.LockUser(id);
        }
    }
}
