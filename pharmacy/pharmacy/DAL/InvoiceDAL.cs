using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.Models;

namespace pharmacy.DAL
{
    public class InvoiceDAL : DbHelper
    {
        public bool AddInvoiceWithID(Invoice invoice)
        {
            string query = @"INSERT INTO Invoices (InvoiceDate, CustomerID, TotalAmount, PaymentStatus)
                     OUTPUT INSERTED.InvoiceID
                     VALUES (@InvoiceDate, @CustomerID, @TotalAmount, @PaymentStatus)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                cmd.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                cmd.Parameters.AddWithValue("@PaymentStatus", invoice.PaymentStatus);

                try
                {
                    OpenConnection();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("خطأ في إضافة الفاتورة: " + ex.Message,
                        "Database Error", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                    return false; 
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        public static int GetID(int n)
        {
            int result = 0;
            string query = "SELECT InvoiceID FROM Invoices WHERE CustomerID = @name";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", n);

                try
                {
                    conn.Open();
                    object value = cmd.ExecuteScalar();

                    if (value != null && value != DBNull.Value)
                    {
                        result = Convert.ToInt32(value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
        }

        public List<Invoice> GetAllInvoices()
        {
            List<Invoice> invoice = new List<Invoice>();
            string query = "SELECT InvoiceID , InvoiceDate, CustomerID ,TotalAmount ,PaymentStatus FROM Invoices";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    OpenConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            invoice.Add(new Invoice
                            {
                                InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                                InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                PaymentStatus = reader["PaymentStatus"].ToString()
                            });
                        }
                    }
                }

                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("خطأ في جلب البيانات: " + ex.Message,
                        "Database Error", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }

                finally
                {
                    CloseConnection();
                }
        }
            return invoice;
        }
}
}