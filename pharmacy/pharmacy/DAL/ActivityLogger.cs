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
    public static class ActivityLogger
    {

        

        public static void Log(String ActionType, string ActionDetails,string id,string username)
        {



        string conn = @"Data Source=DESKTOP-627OQ7U\SQLEXPRESS;Initial Catalog=PharmaDB;Integrated Security=True";
           
            string sql = "Insert into UserActivityLog(UserID,Username,ActionType,ActionDetails) values(@UserID,@Username,@ActionType,@ActionDetails)";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", id);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@ActionType", ActionType);
                    command.Parameters.AddWithValue("@ActionDetails", ActionDetails);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
