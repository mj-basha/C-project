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
    public class EmployeeDAL : DbHelper
    {
        public static bool AddEmployee(Employee employee)
        {
            try
            {
                OpenConnection();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Employees (FullName, JobTitle, EmploymentStatus) VALUES (@FullName, @JobTitle, @EmploymentStatus)", connection))
                {
                    cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                    cmd.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
                    cmd.Parameters.AddWithValue("@EmploymentStatus", employee.EmploymentStatus);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت اضافة الموظف","تم",MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public static void DeleteEmployee(int n)
        {
            OpenConnection();
            var cmd = new SqlCommand("Delete from Employees where EmployeeID=@n", connection);
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

        public static void UpdatStatus(string n,string s)
        {
            OpenConnection();
            var cmd = new SqlCommand("UPDATE Employees SET EmploymentStatus = @s where FullName = @n", connection);
            cmd.Parameters.AddWithValue("@s", s);
            cmd.Parameters.AddWithValue("@n", n);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تغيير حالة التوظيف بنجاح!");
               

            }
            catch (SqlException ex)
            {
                MessageBox.Show("اسم الموظف غير موجود ", "خطأ" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        public static DataTable SearchEmployee(int n)
        {
            DataTable dt = new DataTable();
            string query = "SELECT EmployeeID, FullName, JobTitle, EmploymentStatus FROM Employees WHERE EmployeeID LIKE @n && IsDeleted=0";

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

        public static DataTable GetAllEmployees()
        {
            try
            {

                OpenConnection();
                var da = new SqlDataAdapter("SELECT EmployeeID,FullName, JobTitle,EmploymentStatus FROM Employees", connection);
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
