using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pharmacy.Models;

namespace pharmacy.DAL
{
    public class MedicineDAL : DbHelper
    {
        public static bool AddMedicine(Medicine medicine)
        {
           
                try
                {
                    OpenConnection();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Medicines ( Name, Manufacturer ,Category,quantityID,UnitPrice,SupplierID) VALUES ( @Name, @Manufacturer, @Category,@quantityID, @UnitPrice, @SupplierID)", connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", medicine.Name);
                        cmd.Parameters.AddWithValue("@Manufacturer", medicine.Manufacturer);
                        cmd.Parameters.AddWithValue("@Category", medicine.Category);
                        cmd.Parameters.AddWithValue("@UnitPrice", medicine.UnitPrice);
                        cmd.Parameters.AddWithValue("@quantityID", medicine.quantityID);
                        cmd.Parameters.AddWithValue("@SupplierID", medicine.SupplierID);

                    cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت اضافة الدواء", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
         
        public static void DeleteMedicine(int n)
        {

            OpenConnection();
            var cmd = new SqlCommand("UPDATE Medicines SET IsDeleted=1 where MedicineID=@n ", connection);
            cmd.Parameters.AddWithValue("@n", n);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم المسح بنجاح!");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("اسم المستخدم غير موجود ", "خطأ" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        public static DataTable Search(int n)
        {
            DataTable dt = new DataTable();
            string query = "SELECT MedicineID, Name, Manufacturer ,Category ,UnitPrice,quantityID,SupplierID FROM Medicines WHERE MedicineID LIKE @n && IsDeleted=0";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@n", "%" + n + "%");

            try
            {
                OpenConnection();
                cmd.Connection = connection;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء البحث:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        public static DataTable SearchByName(string n)
        {
            DataTable dt = new DataTable();
            string query = "SELECT  MedicineID,Name, Manufacturer ,Category ,UnitPrice FROM Medicines WHERE Name=@n AND IsDeleted=0";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@n", n);

            try
            {
                OpenConnection();
                cmd.Connection = connection;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء البحث:\n{ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        public static DataTable GetAllMedicines()
        {
            try
            {

                OpenConnection();
                var da = new SqlDataAdapter("SELECT MedicineID, Name, Manufacturer ,Category ,UnitPrice,quantityID,SupplierID  FROM Medicines where IsDeleted=0", connection);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;

            }

            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("خطأ في جلب البيانات: " + ex.Message,
                    "Database Error", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }

            finally
            {
                CloseConnection();
            }
        }

       
    }
}
