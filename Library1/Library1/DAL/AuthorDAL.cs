using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1.Models;

namespace Library1.DAL
{
    public class AuthorDAL :DbHelper
    {
        public bool AddAuthor(Author author)
        {
            string query = "INSERT INTO Authors (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)";
            using (SqlCommand cmd = new SqlCommand(query, base.connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", author.FirstName);
                cmd.Parameters.AddWithValue("@LastName", author.LastName);
                cmd.Parameters.AddWithValue("@Age", author.Age);

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

        public List<Author> GetAllAuthors()
        {
            List<Author> authors = new List<Author>();
            string query = "SELECT AuthorID, FirstName, LastName, Age FROM Authors";
            using (SqlCommand cmd = new SqlCommand(query, base.connection))
            {
                try
                {
                    OpenConnection();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            authors.Add(new Author
                            {
                                AuthorID = Convert.ToInt32(reader["AuthorID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Age = Convert.ToInt32(reader["Age"])
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
            return authors;
        }
    }
}
