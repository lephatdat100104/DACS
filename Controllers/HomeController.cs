using System.Diagnostics;
using DACS.Models;
using Microsoft.AspNetCore.Mvc;

namespace DACS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Dùng ?? ghi log (theo dõi, debug)

        // Inject Logger qua constructor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ? Trang ch?
        public IActionResult Index()
        {
            return View(); // Tr? v? view Index.cshtml
        }

        // ? Trang chính sách b?o m?t
        public IActionResult Privacy()
        {
            return View();
        }

        // ? Trang gi?i thi?u
        public IActionResult About()
        {
            return View();
        }

        // ? Trang liên h?
        public IActionResult Contact()
        {
            return View();
        }

        // ? Trang liên h? khác (có th? tùy ch?nh n?i dung riêng)
        public IActionResult ContactPage()
        {
            return View();
        }

        // ? Trang báo l?i
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Truy?n thông tin l?i vào view Error
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
