using DACS.Models;
using DACS.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DACS.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inject DbContext để làm việc với cơ sở dữ liệu
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register() => View(); // Trả về view đăng ký

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu hợp lệ
            {
                // Kiểm tra email đã tồn tại chưa
                if (await _context.Users.AnyAsync(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại.");
                    return View(model);
                }

                // Tạo đối tượng user mới
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    // Mã hóa mật khẩu bằng BCrypt
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    Role = "student" // Gán role mặc định
                };

                // Lưu vào DB
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Sau khi đăng ký xong thì chuyển đến trang đăng nhập
                return RedirectToAction("Login");
            }

            return View(model); // Nếu có lỗi thì trả lại view
        }

        // GET: /Account/Login
        public IActionResult Login() => View(); // Trả về view đăng nhập

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // Kiểm tra dữ liệu hợp lệ
            {
                // Tìm user theo email
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                // Kiểm tra user tồn tại và mật khẩu đúng
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                {
                    // ✅ Lưu UserId vào Session (nếu muốn dùng cho các chức năng khác)
                    HttpContext.Session.SetInt32("UserId", user.UserId);

                    // ✅ Tạo danh sách Claims (dùng để lưu thông tin người dùng trong cookie)
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()), // ID người dùng
                        new Claim(ClaimTypes.Name, user.Name), // Tên người dùng
                        new Claim(ClaimTypes.Email, user.Email), // Email
                        new Claim(ClaimTypes.Role, user.Role ?? "student") // Role (quyền)
                    };

                    // Tạo identity và principal từ claims
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Đăng nhập (lưu cookie xác thực)
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Chuyển về trang chủ
                    return RedirectToAction("Index", "Home");
                }

                // Nếu sai email hoặc mật khẩu thì báo lỗi
                ViewBag.Error = "Email hoặc mật khẩu không đúng.";
            }

            return View(model); // Trả lại view nếu có lỗi
        }

        // /Account/Logout
        public async Task<IActionResult> Logout()
        {
            // Xóa session
            HttpContext.Session.Clear();

            // Xóa cookie đăng nhập
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Chuyển về trang đăng nhập
            return RedirectToAction("Login");
        }
    }
}
 