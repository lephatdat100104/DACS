using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DACS.Models;

namespace DACS.Controllers
{
    [Authorize(Roles = "admin")] // ✅ Chỉ admin mới được truy cập
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context; // ✅ DbContext kết nối CSDL

        // ✅ Inject DbContext qua constructor
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Trang danh sách người dùng
        public IActionResult Index()
        {
            // 🔹 Lấy tất cả người dùng từ DB
            var users = _context.Users.ToList();
            return View(users); // Trả dữ liệu ra View
        }

        // ✅ GET: Trang chỉnh sửa quyền (Role)
        public IActionResult Edit(int id)
        {
            // 🔹 Tìm user theo ID
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null) return NotFound(); // Không tìm thấy user

            return View(user); // Trả dữ liệu ra form edit
        }

        // ✅ POST: Lưu quyền mới
        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            // 🔹 Tìm user trong DB
            var user = _context.Users.FirstOrDefault(u => u.UserId == updatedUser.UserId);
            if (user == null) return NotFound();

            // 🔹 Cập nhật quyền
            user.Role = updatedUser.Role;
            _context.SaveChanges(); // Lưu thay đổi vào DB

            return RedirectToAction("Index"); // Quay lại danh sách
        }

        // ✅ Xoá người dùng
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // 🔹 Tìm user cần xóa
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null) return NotFound();

            // 🔹 Xóa user và lưu DB
            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index"); // Quay lại danh sách
        }
    }
}
