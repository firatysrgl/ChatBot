using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// DÜZELTME 1: Namespace ismini senin projene uygun hale getirdik
namespace MyChatbot
{
    public partial class Form1 : Form
    {
        // --- AYARLAR ---
        private static readonly string ApiKey = "BURAYA_SK_ILE_BASLAYAN_KEY_GELECEK";
        private static readonly string ApiUrl = "https://api.openai.com/v1/chat/completions";

        private string chatHistory = "[{\"role\": \"system\", \"content\": \"Sen yardımsever bir asistanın.\"}]";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; // Basit hataları önlemek için
        }

        // DÜZELTME 2: Hata veren fonksiyon ismini tam olarak buraya yazdık
        // Eğer bu satırın hemen altında 'txtInput' veya 'btnSend' altı kırmızı yanarsa
        // Tasarım ekranına gidip o kutuların ismini kontrol etmen gerekir.
        private async void BtnGönder_Click(object sender, EventArgs e)
        {
            // NOT: Tasarımdaki TextBox'ın adı textBox1 ise aşağıdaki 'txtInput' yerine 'textBox1' yazmalısın.
            // Tasarımdaki Butonun adı button1 ise aşağıdaki 'btnSend' yerine 'button1' yazmalısın.

            // Buradaki isimleri senin tasarımına uyacak şekilde genel isimler (textBox1 gibi) varsayıyorum:
            // Lütfen hatayı gidermek için kendi tasarımındaki isimleri buraya yaz.
            // Örnek: txtInput yerine textBox1

            string userMessage = "";

            // TextBox ismini bulmaya çalışalım (genelde textBox1 veya txtInput olur)
            // Kodu yapıştırdığında hangisinin altı kızarırsa onu silip doğrusunu yaz.
            if (Controls.ContainsKey("txtInput"))
                userMessage = Controls["txtInput"].Text.Trim();
            else if (Controls.ContainsKey("textBox1"))
                userMessage = Controls["textBox1"].Text.Trim();
            else
                userMessage = "TextBox Bulunamadı! İsmi kontrol et.";

            if (string.IsNullOrEmpty(userMessage)) return;

            // Yazıları ekrana ekleme
            AppendTextToChat($"Sen: {userMessage}", Color.Blue);

            // TextBox'ı temizle (İsmi txtInput veya textBox1 ise düzelt)
            // txtInput.Clear(); 

            // Geçmişe ekle
            chatHistory = chatHistory.TrimEnd(']') + $", {{\"role\": \"user\", \"content\": \"{userMessage}\"}}]";

            // API'ye sor
            string botResponse = await GetGptResponse(chatHistory);

            // Cevabı yaz
            AppendTextToChat($"Bot: {botResponse}", Color.Green);

            // Geçmişi güncelle
            string safeBotResponse = botResponse.Replace("\"", "\\\"");
            chatHistory = chatHistory.TrimEnd(']') + $", {{\"role\": \"assistant\", \"content\": \"{safeBotResponse}\"}}]";
        }

        private async Task<string> GetGptResponse(string jsonMessages)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

                string jsonContent = $@"{{ ""model"": ""gpt-3.5-turbo"", ""messages"": {jsonMessages}, ""temperature"": 0.7 }}";
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync(ApiUrl, httpContent);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode) return "Hata: " + response.StatusCode;

                    string searchToken = "\"content\": \"";
                    int startIndex = responseString.IndexOf(searchToken);
                    if (startIndex == -1) return "Bot cevap veremedi.";

                    startIndex += searchToken.Length;
                    int endIndex = responseString.IndexOf("\"", startIndex);

                    string content = responseString.Substring(startIndex, endIndex - startIndex);
                    return content.Replace("\\n", "\n").Replace("\\\"", "\"");
                }
                catch (Exception ex) { return "Bağlantı Hatası: " + ex.Message; }
            }
        }

        private void AppendTextToChat(string text, Color color)
        {
            // Buradaki RichTextBox ismi de 'richTextBox1' olabilir. Kontrol et.
            // Eğer rtbChat altı kırmızıysa 'richTextBox1' yap.
            if (Controls.ContainsKey("rtbChat"))
            {
                RichTextBox rtb = (RichTextBox)Controls["rtbChat"];
                rtb.SelectionColor = color;
                rtb.AppendText(text + "\n\n");
            }
            else if (Controls.ContainsKey("richTextBox1"))
            {
                RichTextBox rtb = (RichTextBox)Controls["richTextBox1"];
                rtb.SelectionColor = color;
                rtb.AppendText(text + "\n\n");
            }
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }
    }
}