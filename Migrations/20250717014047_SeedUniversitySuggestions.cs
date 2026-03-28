using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DACS.Migrations
{
    /// <inheritdoc />
    public partial class SeedUniversitySuggestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UniversitySuggestions",
                columns: new[] { "Id", "DominantType", "Major", "UniversityName", "Website" },
                values: new object[,]
                {
                    { 4, "Sáng tạo", "Truyền thông đa phương tiện", "ĐH FPT", "https://daihoc.fpt.edu.vn" },
                    { 5, "Xã hội", "Xã hội học", "ĐH Khoa học Xã hội & Nhân văn", "https://hcmussh.edu.vn" },
                    { 6, "Xã hội", "Tâm lý học", "ĐH Sư phạm TP.HCM", "https://hcmue.edu.vn" },
                    { 7, "Quản lý", "Quản trị kinh doanh", "ĐH Kinh tế TP.HCM", "https://ueh.edu.vn" },
                    { 8, "Thực tế", "Nông nghiệp", "ĐH Nông Lâm TP.HCM", "https://hcmuaf.edu.vn" },
                    { 9, "Nghiên cứu", "Khoa học dữ liệu", "ĐH Quốc tế - ĐHQG TP.HCM", "https://hcmiu.edu.vn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UniversitySuggestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UniversitySuggestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UniversitySuggestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UniversitySuggestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UniversitySuggestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UniversitySuggestions",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
