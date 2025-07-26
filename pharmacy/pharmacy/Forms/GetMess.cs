using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using pharmacy.Models;

namespace pharmacy.Forms
{
    public partial class GetMess : Form
    {

        public readonly HttpClient client = new HttpClient();
        public GetMess()
        {
            InitializeComponent();
        }

        private async void btnFetchData_Click(object sender, EventArgs e)
        {



            string apiUrl = "http://dev2.alashiq.com/message.php?systemId=12345678832";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
           

            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

            if (apiResponse.success)
            {

                textBox1.Text = responseBody;

                MessageBox.Show("تم تحميل الرسائل بنجاح");
            }
            else
            {
                MessageBox.Show("فشل في جلب الرسائل: " + apiResponse.message);
            }
        }

      
    }


}
          

