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
    public class QuantityDAL: DbHelper
    {
        public static bool AddQuantity(Quantity quantity)
        {
           


         
            try
            {
                OpenConnection();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Quantity ( quantityOF, ExpiryDate, name) VALUES (@quantityOF, @ExpiryDate, @name)", connection))
                {
                    cmd.Parameters.AddWithValue("@quantityOF", quantity.quantityOF);
                    cmd.Parameters.AddWithValue("@ExpiryDate", quantity.ExpiryDate);
                    cmd.Parameters.AddWithValue("@name", quantity.name);

                    cmd.ExecuteNonQuery();
                    
                    return true;
                }
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
        
        public static int GetID(string n)
        {
            int result=0;
            string query = "SELECT quantityID FROM Quantity WHERE name = @name";

            
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", n);

                try
                {
                    OpenConnection();
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
                finally {  CloseConnection(); }
            }

            return result;
        }

        public static bool decrease(int qid,int q)
        {
            string query = "Update Quantity SET quantityOF=quantityOF-@q where quantityID=@id";
          
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", qid);
                    cmd.Parameters.AddWithValue("@q", q);

                    cmd.ExecuteNonQuery();
                    return true;


                }
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

        public static int exd()
        {
            int result = 0;
            string query = "SELECT quantityID FROM Quantity WHERE ExpiryDate < GETDATE()";

            
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {


                try
                {
                    OpenConnection();
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
                finally { CloseConnection(); }
            }

            return result;
        }
        


        public List<Quantity> GetAllQuantitys()
        {
            List<Quantity> quantity = new List<Quantity>();
            string query = "SELECT quantityID , quantityOF, ExpiryDate FROM Medicines";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                try
                {
                    OpenConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            quantity.Add(new Quantity
                            {
                                quantityID = Convert.ToInt32(reader["quantityID"]),
                                //quantityOF = reader["quantityOF"].ToString(),
                                ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"])
                               

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
            return quantity;
        }
    }
}
