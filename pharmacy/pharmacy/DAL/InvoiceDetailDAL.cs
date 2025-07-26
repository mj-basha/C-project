using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy.Models;

namespace pharmacy.DAL
{
    public class InvoiceDetailDAL : DbHelper
    {
        public bool AddInvoiceDetail(InvoiceDetail invoicedetail)
        {
            string query = "INSERT INTO InvoiceDetails ( InvoiceID, MedicineID ,Quantity ,UnitPrice) VALUES ( @InvoiceID, @MedicineID, @Quantity, @UnitPrice)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                
                cmd.Parameters.AddWithValue("@InvoiceID", invoicedetail.InvoiceID);
                cmd.Parameters.AddWithValue("@MedicineID", invoicedetail.MedicineID);
                cmd.Parameters.AddWithValue("@Quantity", invoicedetail.Quantity);
                cmd.Parameters.AddWithValue("@UnitPrice", invoicedetail.UnitPrice);


                try
                {
                    OpenConnection();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("خطأ في الإضافة: " + ex.Message,
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

        public List<InvoiceDetail> GetAllInvoiceDetails()
        {
            List<InvoiceDetail> invoicedetail = new List<InvoiceDetail>();
            string query = "SELECT InvoiceDetailID , InvoiceID, MedicineID ,Quantity ,UnitPrice FROM InvoicesDetails";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    OpenConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            invoicedetail.Add(new InvoiceDetail
                            {
                                InvoiceDetailID = Convert.ToInt32(reader["InvoiceDetailID"]),
                                InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                                MedicineID = Convert.ToInt32(reader["MedicineID"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
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
            return invoicedetail;
        }
    }
}
