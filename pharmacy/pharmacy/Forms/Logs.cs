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

namespace pharmacy.Forms
{
    public partial class Logs : Form
    {
        string connectionString = @"Server=DESKTOP-627OQ7U\SQLEXPRESS;Database=PharmaDB;Trusted_Connection=True;";
        public Logs()
        {
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var da = new SqlDataAdapter("SELECT UserName, ActionType, ActionDetails FROM UserActivityLog", conn);
            var dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
