using Microsoft.AspNetCore.Mvc;
using DACS.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class FinalYearTestController : Controller
{
    private readonly ApplicationDbContext _context;

    public FinalYearTestController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Hiển thị câu hỏi
    public IActionResult Index()
    {
        var questions = _context.FinalYearQuestions
            .Include(q => q.Answers)
            .ToList();

        return View(questions);
    }

    // Nộp bài test
    [HttpPost]
    public IActionResult Submit(Dictionary<int, int> answers)
    {
        int totalScore = 0;

        foreach (var entry in answers)
        {
            var answer = _context.FinalYearAnswers.Find(entry.Value);
            if (answer != null) totalScore += answer.Score;
        }

        string recommendation;
        if (totalScore >= 5)
            recommendation = "Bạn đã sẵn sàng đi làm. Hãy tập trung chuẩn bị CV và kỹ năng phỏng vấn.";
        else if (totalScore >= 3)
            recommendation = "Bạn nên tham gia thêm thực tập và workshop nghề nghiệp.";
        else
            recommendation = "Bạn cần xác định mục tiêu nghề nghiệp rõ ràng hơn và bổ sung kỹ năng.";

        // Lưu kết quả
        var result = new FinalYearTestResult
        {
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            TotalScore = totalScore,
            Recommendation = recommendation,
            TakenAt = DateTime.Now
        };
        _context.FinalYearTestResults.Add(result);
        _context.SaveChanges();

        return View("Result", result);
    }
}
