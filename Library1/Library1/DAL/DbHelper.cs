using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library1.DAL
{
    public class DbHelper : IDisposable
    {
        protected string connectionString = @"Data Source=DESKTOP-627OQ7U\SQLEXPRESS;Initial Catalog=MyLibraryDB;Integrated Security=True";

        protected SqlConnection connection;

        public DbHelper()
        {
            connection = new SqlConnection(connectionString);
        }

        protected void OpenConnection()
        {
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }

                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("خطأ في الاتصال:" + ex.Message, "خطأ قاعدة البيانات",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        protected void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void Dispose()
        {
            CloseConnection();
        }

    }
}
