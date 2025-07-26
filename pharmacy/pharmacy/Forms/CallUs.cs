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
//using Newtonsoft.Json;
using pharmacy.Models;
using System.Text.Encodings.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;

namespace pharmacy.Forms
{
    public partial class CallUs : Form
    {
        private readonly UserMessage userMessage;
        static string EscapeString(string input)
        {
            return input?.Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r");
        }
        public CallUs(UserMessage userMessage)
        {
            InitializeComponent();
            this.userMessage = userMessage;
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = "http://dev2.alashiq.com/send.php?systemId=12345678832";

            // Validate inputs
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "اكتب اسمك");
                return;
            }
            else errorProvider1.SetError(textBox1, "");

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "اكتب رقم المستخدم");
                return;
            }
            else errorProvider1.SetError(textBox2, "");

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "اكتب رسالتك");
                return;
            }
            else errorProvider1.SetError(textBox4, "");

            // Parse and prepare data
            if (!int.TryParse(textBox2.Text, out int userId))
            {
                errorProvider1.SetError(textBox2, "رقم المستخدم يجب أن يكون رقمًا");
                return;
            }

            

           

            try
            {

                string mess = Messagecont();
                bool sucsses = await userMessage.Send(mess);
                

              

                if (sucsses)
                {
                    MessageBox.Show("✅ تم ارسال البيانات بنجاح");
                }
                else
                {
                    MessageBox.Show($"❌ خطأ في الإرسال");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ استثناء أثناء الإرسال: {ex.Message}");
            }

        }

        private string Messagecont()
        {
            string username = textBox1.Text.Trim();
            string userId = textBox2.Text.Trim();
            string msg = textBox4.Text.Trim();

            // نعيدهم بهذا الشكل: username|user_id|message
            return $"{username}|{userId}|{msg}";
        }

    }
    }

