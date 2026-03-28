using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DACS.Services
{
    /// <summary>
    /// Service để giao tiếp với API OpenAI (ChatGPT & Moderation)
    /// </summary>
    public class OpenAIService
    {
        private readonly HttpClient _httpClient; // Đối tượng gọi API
        private readonly string _apiKey;         // API Key OpenAI

        // Constructor: Inject HttpClientFactory và IConfiguration
        public OpenAIService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClient = httpClientFactory.CreateClient(); // Tạo HttpClient
            _apiKey = config["OpenAI:ApiKey"];              // Lấy API Key từ appsettings.json
        }

        /// <summary>
        /// 📌 Gửi tin nhắn đến ChatGPT và nhận phản hồi
        /// </summary>
        public async Task<string> GetChatbotReplyAsync(string userMessage)
        {
            var url = "https://api.openai.com/v1/chat/completions"; // Endpoint của Chat API

            // Dữ liệu gửi lên API
            var requestBody = new
            {
                model = "gpt-4o-mini", // Hoặc "gpt-3.5-turbo"
                messages = new[]
                {
                    new { role = "system", content = "Bạn là trợ lý tư vấn nghề nghiệp dựa trên kết quả trắc nghiệm Holland." },
                    new { role = "user", content = userMessage }
                },
                max_tokens = 500 // Giới hạn số token trả về
            };

            // Chuyển object → JSON và set Content-Type
            var requestJson = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            // Thêm header Authorization với API Key
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            // Gửi POST request
            var response = await _httpClient.PostAsync(url, requestJson);
            response.EnsureSuccessStatusCode(); // Nếu lỗi HTTP → throw exception

            // Đọc phản hồi dạng chuỗi
            var jsonResponse = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(jsonResponse);

            // Lấy nội dung trả lời từ JSON
            var reply = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return reply ?? ""; // Trả về chuỗi rỗng nếu null
        }

        /// <summary>
        /// 📌 Kiểm tra nội dung người dùng gửi có an toàn không (Moderation API)
        /// </summary>
        public async Task<bool> IsContentSafeAsync(string message)
        {
            var url = "https://api.openai.com/v1/moderations"; // Endpoint kiểm duyệt

            // Nội dung gửi lên API
            var requestBody = new
            {
                model = "omni-moderation-latest", // Model kiểm duyệt mới nhất
                input = message
            };

            var requestJson = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync(url, requestJson);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(jsonResponse);

            // Lấy cờ "flagged" từ kết quả
            var flagged = doc.RootElement
                .GetProperty("results")[0]
                .GetProperty("flagged")
                .GetBoolean();

            return flagged == false; // flagged = true → không an toàn → trả về false
        }
    }
}
