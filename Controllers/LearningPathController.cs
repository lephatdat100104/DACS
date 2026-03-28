using Microsoft.AspNetCore.Mvc;
using DACS.Models; // ✅ Chứa ApplicationDbContext và các model liên quan
using System.Linq;

public class LearningPathController : Controller
{
    private readonly ApplicationDbContext _context; // ✅ Kết nối tới cơ sở dữ liệu

    // ✅ Constructor inject DbContext để truy vấn DB
    public LearningPathController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Hiển thị lộ trình học dựa trên dominantType (loại tính cách nghề nghiệp)
    public IActionResult Index(string dominantType)
    {
        // 🔹 Nếu không truyền dominantType, quay lại trang chủ
        if (string.IsNullOrEmpty(dominantType))
            return RedirectToAction("Index", "Home");

        // 🔹 Lấy danh sách các bước học tập phù hợp với loại tính cách
        var steps = _context.LearningPathSteps
            .Where(l => l.DominantType == dominantType) // Lọc theo dominantType
            .OrderBy(l => l.Id) // Sắp xếp theo Id (thứ tự bước)
            .ToList();

        // 🔹 Gửi dominantType sang View để hiển thị tiêu đề hoặc mô tả
        ViewBag.DominantType = dominantType;

        // 🔹 Trả danh sách bước học về View
        return View(steps);
    }
}
