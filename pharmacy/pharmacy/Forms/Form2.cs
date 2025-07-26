using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.DAL;
using pharmacy.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using pharmacy.Models;

namespace pharmacy
{
    public partial class Form2 : Form
    {
        private readonly string role;
        private readonly int id;
        private readonly string username;
        UserMessage messageService = new HttpUserMessage();
        public Form2(string role,int id,string username)
        {
            InitializeComponent();
            this.role = role;
            this.id = id;
            this.username = username;
            ConfigureAccess();
           
        }

        private void ConfigureAccess()
        {
            if (role == "editor")
            {
                button1.Enabled = false;
                btnUsers.Enabled = false;
                btnMedicine.Enabled = false;
                btnSupplier.Enabled = false;
                btnLogs.Enabled = false;
                btnGetMess.Enabled = false;
            }
            else if (role == "viewer")
            {
                button1.Enabled = false;
                btnUsers.Enabled = false;
                btnMedicine.Enabled = false;
                btnSupplier.Enabled = false;
                btnLogs.Enabled = false;
                btnInvoice.Enabled = false;
                btnGetMess.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployForm employeeForm = new EmployForm(id,username);
            ShowFormin(employeeForm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                                  "Confirm Logout",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("You have been logged out successfully.",
                                "Logout",
                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                ActivityLogger.Log("logout", "تم تسجيل الخروج بنجاح", id, username);


                
                this.Close();

            }
            Form1 form = new Form1();
            form.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm(id,username);
            ShowFormin(usersForm);
        }

        private void ShowFormin(Form formtoshow)
        {
            panel1.Controls.Clear();
            formtoshow.TopLevel = false;
            formtoshow.FormBorderStyle = FormBorderStyle.None;
            formtoshow.Dock = DockStyle.Fill;
            panel1.Controls.Add(formtoshow);
            formtoshow.Show();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            Form4 sForm = new Form4(id,username);
            ShowFormin(sForm);
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            Form3 sForm = new Form3(id,username);
            ShowFormin(sForm);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm sForm = new SupplierForm(id,username);
            ShowFormin(sForm);
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {

            Logs sForm = new Logs();
            ShowFormin(sForm);
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            AboutUs sForm = new AboutUs(id,username);
            ShowFormin(sForm);
        }

        private void btnCallUs_Click(object sender, EventArgs e)
        {
            CallUs sForm = new CallUs(messageService);
            ShowFormin(sForm);
        }

        private void btnGetMess_Click(object sender, EventArgs e)
        {
            GetMess sForm = new GetMess();
            ShowFormin(sForm);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int qid=QuantityDAL.exd();
            if (qid > 0)
            {
                int mid=MedicineDAL.getmid(qid);
                string mname=MedicineDAL.getmname(mid);
                MessageBox.Show("Medicine "+mname+" where MedicineID= "+mid+" Expierd");
            }
        }
    }
}
