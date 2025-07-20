using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using pharmacy.DAL;
using pharmacy.Models;


namespace pharmacy
{
    public partial class Form1 : Form
    {
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string hashedPassword = DbHelper.ComputeSha256Hash(password);
            string role, errorMessage;
            


            if (string.IsNullOrEmpty(password))
            {
                errorProvider1.SetError(txtPassword, "يجب ادخال كلمة المرور ");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
            if (string.IsNullOrEmpty(username))
            {
                errorProvider1.SetError(txtUsername, "يجب ادخال اسم المستخدم ");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
            int id=UsersDAL.getid(username);



            if (DbHelper.ValidateUser(username, password, out role, out errorMessage))
            {
                MessageBox.Show("تم تسجيل الدخول بنجاح.");
                ActivityLogger.Log("login", "تم تسجيل الدخول بنجاح", Convert.ToString(id), username);
                DbHelper.f(username,Convert.ToString(id));
                this.Close();
            }


        }         
                    
                 

       

    }

}
    

