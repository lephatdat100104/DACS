using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DACS.Services;
using System.Threading.Tasks;
using DACS.Models;
using System.Collections.Generic;
using DACS.Models.Services;

namespace DACS.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly FAQService _faqService;

        public AdminController(FAQService faqService)
        {
            _faqService = faqService;
        }

        // Trang danh sách FAQ + thống kê + form thêm mới
        public async Task<IActionResult> FAQ()
        {
            List<FAQ> faqs = await _faqService.GetAllFAQAsync();
            return View(faqs);
        }

        // Thêm FAQ
        [HttpPost]
        public async Task<IActionResult> AddFAQ(string question, string answer)
        {
            if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
            {
                ModelState.AddModelError("", "Câu hỏi và câu trả lời không được để trống.");
                var faqs = await _faqService.GetAllFAQAsync();
                return View("FAQ", faqs);
            }

            await _faqService.AddFAQAsync(question, answer);
            ViewBag.Success = "Đã thêm FAQ thành công!";
            var updatedFaqs = await _faqService.GetAllFAQAsync();
            return View("FAQ", updatedFaqs);
        }

        // Sửa FAQ
        [HttpPost]
        public async Task<IActionResult> EditFAQ(int id, string question, string answer)
        {
            await _faqService.UpdateFAQAsync(id, question, answer);
            var faqs = await _faqService.GetAllFAQAsync();
            ViewBag.Success = "Đã cập nhật FAQ thành công!";
            return View("FAQ", faqs);
        }

        // Xóa FAQ
        [HttpPost]
        public async Task<IActionResult> DeleteFAQ(int id)
        {
            await _faqService.DeleteFAQAsync(id);
            var faqs = await _faqService.GetAllFAQAsync();
            ViewBag.Success = "Đã xóa FAQ thành công!";
            return View("FAQ", faqs);
        }
    }
}
