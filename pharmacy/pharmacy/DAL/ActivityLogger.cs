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
    public  class ActivityLogger: DbHelper
    {

        

        public static void Log(String ActionType, string ActionDetails,int id,string username)
        {

           
            string sql = "Insert into UserActivityLog(UserID,Username,ActionType,ActionDetails) values(@UserID,@Username,@ActionType,@ActionDetails)";
           
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", id);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@ActionType", ActionType);
                    command.Parameters.AddWithValue("@ActionDetails", ActionDetails);

                try
                {
                    OpenConnection();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show("خطأ  : " + ex.Message,
                        "Database Error", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                    
                }
                finally
                {
                    CloseConnection();
                }

            }
            }
        }
    }

