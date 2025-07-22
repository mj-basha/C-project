using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;


namespace pharmacy.Forms
{
    public class HttpUserMessage : UserMessage
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "http://dev2.alashiq.com/send.php?systemId=12345678832";

        public HttpUserMessage(HttpClient client = null)
        {
            httpClient = client ?? new HttpClient();
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        public async Task<bool> Send(string message)
        {
            try
            {
                // نفترض أننا نمرر القيم مفصولة بـ | مثل: "Ali|123|مرحبا"
                var parts = message.Split('|');
                if (parts.Length < 3)
                {
                    MessageBox.Show("❌ بيانات ناقصة!");
                    return false;
                }

                string username = parts[0];
                string userId = parts[1];
                string msg = parts[2];

                var formData = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("user_id", userId),
                new KeyValuePair<string, string>("message", msg)
            });

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, formData);

                string resp = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Response: {resp}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Http Error: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<ContactMessage>> GetAllMessagesAsync() => new List<ContactMessage>();
        public async Task<bool> MarkMessage(int messid) => true;
    }
}

