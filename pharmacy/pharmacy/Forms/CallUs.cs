using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using pharmacy.Models;

namespace pharmacy.Forms
{
    public partial class CallUs : Form
    {
        private readonly HttpClient client=new HttpClient();
        public CallUs()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = "https://yourapi.com/api/contact";

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1,"اكتب اسمك");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "اكتب رقم المستخدم");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "اكتب رقم الهاتف");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "اكتب رسالتك");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }

            ContactMessage message = new ContactMessage
                {
                    name = textBox1.Text,
                    user_id = textBox2.Text,
                    phone = textBox3.Text,
                    message = textBox4.Text
                };

            try
            {
                string json = JsonConvert.SerializeObject(message);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("تم إرسال الرسالة بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء إرسال الرسالة: " + ex.Message);
            }
        }

       
    }
}
