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
    public class UsersDAL : DbHelper
    {
      

        public static void AddUser(Users user)
        {
            
            OpenConnection();
            var cmd = new SqlCommand("INSERT INTO Users (username, password_hash, role) VALUES (@u,@ph,@r)", connection);
            cmd.Parameters.AddWithValue("@u", user.username);
            cmd.Parameters.AddWithValue("@ph", DbHelper.ComputeSha256Hash(user.password_hash));
            cmd.Parameters.AddWithValue("@r", user.role);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الإضافة بنجاح!");

            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("اسم المستخدم موجود مسبقًا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

        }
    

        public static void deleteUser(String us)
        {



            if (string.IsNullOrEmpty(us))
            {
                MessageBox.Show("اكتب اسم المستخدم ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                int id=Convert.ToInt32(us);

                OpenConnection();
                var cmd = new SqlCommand("UPDATE Users SET IsDeleted = 1 where id = @us", connection);
                cmd.Parameters.AddWithValue("@us", id);
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
        }

       public static void changepass(string us,string pa)
        {
            OpenConnection();
            var cmd = new SqlCommand("UPDATE Users SET password_hash = @pa where username = @us", connection);
            cmd.Parameters.AddWithValue("@us", us);
            cmd.Parameters.AddWithValue("@pa", DbHelper.ComputeSha256Hash(pa));
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تغيير كلمة المرور بنجاح!");
               
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

        public static int getid(string n)
        {
            int result = 0;
            string query = "SELECT id FROM Users WHERE username = @name AND IsDeleted=0";

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

        public static DataTable GetAllUsers()
        {
           

            try
                {

                OpenConnection();
                var da = new SqlDataAdapter("SELECT id,username, role, failed_attempts FROM Users where IsDeleted = 0", connection);
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

