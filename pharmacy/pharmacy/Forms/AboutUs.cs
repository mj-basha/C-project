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
        private readonly string id;
        private readonly string username;
        public AboutUs(string id, string username)
        {
            InitializeComponent();
            this.id = id;
            this.username = username;
        }

        private async void AboutUs_Load(object sender, EventArgs e)
        {
            string url = "";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                SystemInfo info = JsonConvert.DeserializeObject<SystemInfo>(json);

                label1.Text = info.Title;
                label2.Text = info.About;
                label3.Text = info.Version;

                MessageBox.Show("تم جلب معلومات النظام بنجاح");
                ActivityLogger.Log("about us", "تم بحث عن معلومات النظام بنجاح", id, username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }

       
    }
}
