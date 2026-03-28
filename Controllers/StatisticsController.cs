using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml; // ✅ Thư viện xử lý Excel
using System.IO;
using System.Linq;
using DACS.Models;

namespace DACS.Controllers
{
    [Authorize(Roles = "admin")] // ✅ Chỉ admin mới được truy cập
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context; // ✅ DbContext kết nối CSDL

        // ✅ Inject DbContext
        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Trang hiển thị thống kê kết quả trắc nghiệm
        public IActionResult CareerTestSummary()
        {
            // 🔹 Nhóm kết quả theo DominantType và đếm số lượng
            var data = _context.CareerTestResults
                .GroupBy(r => r.DominantType)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToList();

            return View(data); // Trả dữ liệu ra View
        }

        // ✅ Xuất thống kê ra file Excel
        public IActionResult ExportCareerStatsToExcel()
        {
            // ⚠️ Bắt buộc: Cấu hình license cho EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // 🔹 Lấy dữ liệu thống kê
            var data = _context.CareerTestResults
                .GroupBy(r => r.DominantType)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToList();

            // 🔹 Tạo file Excel mới
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Career Stats");

            // ✅ Ghi tiêu đề cột
            worksheet.Cells[1, 1].Value = "Loại nghề nghiệp";
            worksheet.Cells[1, 2].Value = "Số lượng";
            worksheet.Row(1).Style.Font.Bold = true; // In đậm tiêu đề

            // ✅ Ghi dữ liệu vào bảng
            for (int i = 0; i < data.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = data[i].Type;  // Loại nghề
                worksheet.Cells[i + 2, 2].Value = data[i].Count; // Số lượng
            }

            // ✅ Tự động điều chỉnh độ rộng cột
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            // ✅ Xuất file ra MemoryStream
            var stream = new MemoryStream();
            package.SaveAs(stream);
            stream.Position = 0;

            // ✅ Trả file Excel về client
            return File(stream,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "ThongKeNgheNghiep.xlsx");
        }
    }
}
