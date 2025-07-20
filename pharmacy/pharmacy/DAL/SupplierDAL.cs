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
    public class SupplierDAL: DbHelper
    {
        public static bool AddSupplier(Supplier supplier)
        {
                try
                {
                    OpenConnection();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Suppliers ( Name, Phone, Email, Address, CompanyName) VALUES ( @Name, @Phone, @Email, @Address, @CompanyName)", connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", supplier.Name);
                        cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                        cmd.Parameters.AddWithValue("@Email", supplier.Email);
                        cmd.Parameters.AddWithValue("@Address", supplier.Address);
                        cmd.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت اضافة المورد", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        public static void DeleteSupplier(int n)
        {
            OpenConnection();
            var cmd = new SqlCommand("UPDATE Suppliers SET IsDeleted=1 where SupplierID=@n", connection);
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
            string query = "SELECT SuppliersID, Name, Phone, Email, Address, CompanyName FROM Employees WHERE SuppliersID LIKE @n && IsDeleted=0";

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

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("اسم الموظف غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public static DataTable GetAllSuppliers()
        {
            try
            {

                OpenConnection();
                var da = new SqlDataAdapter("SELECT SupplierID , Name, Phone, Email, Address, CompanyName FROM Suppliers where IsDeleted = 0", connection);
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

