using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using pharmacy.DAL;
using pharmacy.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pharmacy.Forms
{
    public partial class AboutUs : Form
    {
        private readonly HttpClient client=new HttpClient();
        private readonly int id;
        private readonly string username;
        public AboutUs(int id, string username)
        {
            InitializeComponent();
            this.id = id;
            this.username = username;
        }

        private async void AboutUs_Load(object sender, EventArgs e)
        {
            string url = "http://dev2.alashiq.com/about.php";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0"); 

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    
                   

                    var apires = JsonConvert.DeserializeObject<apires>(json);

                    if (apires?.Data != null)
                    {
                        var info = apires.Data;

                        textBox1.Text =
                            $"عنوان الصفحة: {info.Title}\r\n\r\n" +
                            $"الوصف:\r\n{info.Description}\r\n\r\n" +
                            $"الإصدار: {info.System_Version}\r\n" +
                            $"تاريخ الإنشاء: {info.Created_At}\r\n" +
                            $"آخر تحديث: {info.Updated_At}";
                        ActivityLogger.Log("About Us", "تم فتح صفحة معلومات حول البرنامج",id,username);
                      
                    }
                    else
                    {
                        MessageBox.Show("تعذر جلب البيانات من الخادم (فك JSON أعاد null).");
                    }
                }
            
                  
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }

       
    }
}
