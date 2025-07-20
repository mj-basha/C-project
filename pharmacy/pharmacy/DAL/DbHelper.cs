using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.DAL
{
    public class DbHelper : IDisposable
    {
        protected static string connectionString = @"Data Source=DESKTOP-627OQ7U\SQLEXPRESS;Initial Catalog=PharmaDB;Integrated Security=True";

        protected static SqlConnection connection;

        public DbHelper()
        {
            connection = new SqlConnection(connectionString);
        }

        protected static  void OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        protected static void CloseConnection()
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

        public static  bool ValidateUser(string username, string password, out string role, out string errorMessage)
        {
            role = ""; errorMessage = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT password_hash, role, failed_attempts, last_attempt FROM Users WHERE username = @u",
                    conn);
                cmd.Parameters.AddWithValue("@u", username);
                var r = cmd.ExecuteReader();
                if (!r.Read()) { errorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة."; return false; }

                string dbHash = r.GetString(0), dbRole = r.GetString(1);
                int fails = r.GetInt32(2); DateTime last = r.GetDateTime(3);
                var lockout = GetLockoutDuration(fails);
                if (lockout > TimeSpan.Zero && DateTime.Now - last < lockout)
                {
                    TimeSpan remain = lockout - (DateTime.Now - last);
                    errorMessage = $"تم حظر الحساب من فضلك انتظر {remain.Hours}h {remain.Minutes}m";
                    return false;
                }

                if (ComputeSha256Hash(password) == dbHash)
                {
                    ResetFailed(username);
                    role = dbRole;
                    return true;
                }
                else
                {
                    IncFailed(username, ++fails);
                    errorMessage = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                    return false;
                }
            }
        }

        public static void IncFailed(string user, int val)
        {
            var conn = new SqlConnection(connectionString); conn.Open();
            var c = new SqlCommand("UPDATE Users SET failed_attempts=@f,last_attempt=GETDATE() WHERE username=@u", conn);
            c.Parameters.AddWithValue("@f", val); c.Parameters.AddWithValue("@u", user);
            c.ExecuteNonQuery();
        }

        public static void ResetFailed(string user)
        {
            var conn = new SqlConnection(connectionString); conn.Open();
            var c = new SqlCommand("UPDATE Users SET failed_attempts=0,last_attempt=GETDATE() WHERE username=@u", conn);
            c.Parameters.AddWithValue("@u", user);
            c.ExecuteNonQuery();
        }

        private static TimeSpan GetLockoutDuration(int failedAttempts)
        {
            if (failedAttempts >= 5)
                return TimeSpan.FromHours(12);
            else if (failedAttempts == 4)
                return TimeSpan.FromMinutes(5);
            else if (failedAttempts == 3)
                return TimeSpan.FromMinutes(1);
            else
                return TimeSpan.Zero;
        }

        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("X2")); 
                }
                return builder.ToString();
            }
        }

        public static void f(string value, string id)
        {
            string role = "";

            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-627OQ7U\SQLEXPRESS;Database=PharmaDB;Trusted_Connection=True;"))
            {
                connection.Open();


                string query = "SELECT role FROM Users WHERE username = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", value);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        role = result.ToString();
                    }
                    else
                    {
                        role = "لا توجد بيانات";
                    }
                }
            }
            new Form2(role, id, value).ShowDialog();
        }

    }
}
