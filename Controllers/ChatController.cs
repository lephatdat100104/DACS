using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DACS.Models;
using DACS.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using DACS.Hubs;
using DACS.Models.Services;

namespace DACS.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly OpenAIService _openAIService;
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly FAQService _faqService;        // ✅ Inject FAQService

        public ChatController(ApplicationDbContext context, OpenAIService openAIService, IHubContext<ChatHub> chatHub, FAQService faqService)
        {
            _context = context;
            _openAIService = openAIService;
            _chatHub = chatHub;
            _faqService = faqService;
        }

        // Trang chat chính
        public IActionResult Index()
        {
            var user = GetCurrentUser();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var history = _context.ChatHistories
                .Where(h => h.UserId == user.UserId)
                .OrderBy(h => h.Timestamp)
                .ToList();

            return View(history);
        }

        // API gửi tin nhắn và phản hồi realtime
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
        {
            var user = GetCurrentUser();
            if (user == null)
                return Unauthorized();

            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Tin nhắn không được để trống.");

            // 1️⃣ Kiểm duyệt nội dung
            bool isSafe;
            try
            {
                isSafe = await _openAIService.IsContentSafeAsync(request.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi kiểm duyệt: {ex.Message}");
            }

            if (!isSafe)
                return BadRequest("⚠️ Nội dung vi phạm tiêu chuẩn cộng đồng.");

            string reply;

            // 2️⃣ Tra cứu FAQ trước
            var faqAnswer = await _faqService.GetAnswerAsync(request.Message);
            if (faqAnswer != null)
            {
                reply = faqAnswer;
            }
            else
            {
                // 3️⃣ Nếu không có trong FAQ → gọi OpenAI
                try
                {
                    reply = await _openAIService.GetChatbotReplyAsync(request.Message);
                }
                catch (Exception ex)
                {
                    reply = $"[Lỗi API OpenAI: {ex.Message}]";
                }
            }

            // 4️⃣ Lưu lịch sử chat
            var history = new ChatHistory
            {
                UserId = user.UserId,
                Question = request.Message,
                Answer = reply,
                Timestamp = DateTime.Now
            };
            _context.ChatHistories.Add(history);
            await _context.SaveChangesAsync();

            // 5️⃣ Gửi tin nhắn realtime qua SignalR
            await _chatHub.Clients.All.SendAsync("ReceiveMessage", user.Name, request.Message, reply);

            return Ok(reply);
        }

        // Xem lịch sử chat của user hiện tại
        public IActionResult History()
        {
            var user = GetCurrentUser();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var history = _context.ChatHistories
                .Where(h => h.UserId == user.UserId)
                .OrderByDescending(h => h.Timestamp)
                .ToList();

            return View(history);
        }

        // Admin xem tất cả lịch sử chat
        [Authorize(Roles = "admin")]
        public IActionResult AdminHistory()
        {
            var histories = _context.ChatHistories
                .Include(h => h.User)
                .OrderByDescending(h => h.Timestamp)
                .ToList();

            return View(histories);
        }

        // 🔹 Hàm hỗ trợ: Lấy user hiện tại từ Claims
        private User GetCurrentUser()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
