using DACS.Models.ViewModels;
using DACS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace DACS.Controllers
{
    public class CareerTestController : Controller
    {
        private readonly ApplicationDbContext _context; // Làm việc với CSDL
        private readonly IHttpContextAccessor _httpContextAccessor; // Truy cập thông tin HttpContext (user, claims...)

        // Inject DbContext và HttpContextAccessor qua constructor
        public CareerTestController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // [Authorize] yêu cầu người dùng phải đăng nhập mới vào được
        [Authorize]
        public IActionResult Index()
        {
            // Lấy tất cả câu hỏi kèm các lựa chọn từ DB
            var questions = _context.CareerQuestions
                .Include(q => q.Options) // Include các options của câu hỏi
                .ToList();

            // Tạo ViewModel để gửi ra View
            var viewModel = new CareerTestViewModel
            {
                Questions = questions,
                Answers = new Dictionary<int, int>() // Khởi tạo rỗng, key: questionId, value: optionId
            };

            return View(viewModel); // Trả về trang làm bài test
        }

        [HttpPost]
        [Authorize] // Chỉ người đăng nhập mới submit được
        public IActionResult Submit(Dictionary<int, int> answers)
        {
            // ==========================
            // 1️⃣ Đếm số lượng câu trả lời theo từng nhóm Holland Type
            // ==========================
            var typeCounts = new Dictionary<string, int>(); // key: type (RIASEC), value: số câu chọn

            foreach (var kvp in answers) // kvp: KeyValuePair<QuestionId, OptionId>
            {
                // Lấy option tương ứng trong DB
                var option = _context.CareerOptions.FirstOrDefault(o => o.Id == kvp.Value);
                if (option != null)
                {
                    if (!typeCounts.ContainsKey(option.Type))
                        typeCounts[option.Type] = 0; // Nếu chưa có type này thì thêm vào dictionary

                    typeCounts[option.Type]++; // Tăng số câu đã chọn của type này
                }
            }

            // ==========================
            // 2️⃣ Xác định nhóm chiếm ưu thế
            // ==========================
            var dominant = typeCounts
                .OrderByDescending(t => t.Value) // Sắp xếp giảm dần theo số câu
                .FirstOrDefault().Key ?? "Không xác định";

            // ==========================
            // 3️⃣ Lấy gợi ý ngành học + tài liệu từ DB
            // ==========================
            var suggestion = _context.CareerSuggestions
                .FirstOrDefault(s => s.CareerType == dominant);

            // ==========================
            // 4️⃣ Lấy danh sách trường đào tạo phù hợp
            // ==========================
            var universities = _context.UniversitySuggestions
                .Where(u => u.DominantType == dominant)
                .ToList();

            // ==========================
            // 5️⃣ Lấy UserId từ Claims (bảo mật hơn Session)
            // ==========================
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return Unauthorized(); // Nếu chưa đăng nhập thì chặn
            }

            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            // ==========================
            // 6️⃣ Lưu kết quả bài test vào DB
            // ==========================
            _context.CareerTestResults.Add(new CareerTestResult
            {
                UserId = userId,
                TakenAt = DateTime.Now,
                DominantType = dominant,
                Suggestion = suggestion?.SuggestedMajors ?? "Chưa có dữ liệu"
            });

            _context.SaveChanges();

            // ==========================
            // 7️⃣ Chuẩn bị ViewModel kết quả để hiển thị
            // ==========================
            var viewModel = new CareerTestResultViewModel
            {
                DominantType = dominant,
                Suggestion = suggestion?.SuggestedMajors ?? "Không có gợi ý ngành học",
                Resources = suggestion?.Resources ?? "Không có tài liệu tham khảo",
                UniversitySuggestions = universities // Danh sách trường phù hợp
            };

            // ==========================
            // 8️⃣ Trả về View "Result" để hiển thị kết quả cho người dùng
            // ==========================
            return View("Result", viewModel);
        }
    }
}
