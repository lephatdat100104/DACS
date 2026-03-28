using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DACS.Migrations
{
    /// <inheritdoc />
    public partial class SeedFullLearningPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningPathSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DominantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningPathSteps", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LearningPathSteps",
                columns: new[] { "Id", "Content", "DominantType", "YearStage" },
                values: new object[,]
                {
                    { 1, "Học Toán rời rạc, Tin học đại cương, Cơ sở lập trình", "Kỹ thuật", "Năm 1" },
                    { 2, "Học Cấu trúc dữ liệu, OOP, Cơ sở dữ liệu, mạng máy tính", "Kỹ thuật", "Năm 2" },
                    { 3, "Học Lập trình Web, AI/ML cơ bản, Dự án phần mềm", "Kỹ thuật", "Năm 3" },
                    { 4, "Thực tập, khóa luận tốt nghiệp, học DevOps, học nâng cao ngành", "Kỹ thuật", "Năm 4" },
                    { 5, "Học Toán cao cấp, Khoa học cơ bản, kỹ năng nghiên cứu", "Nghiên cứu", "Năm 1" },
                    { 6, "Học thống kê, phân tích số liệu, viết báo cáo khoa học", "Nghiên cứu", "Năm 2" },
                    { 7, "Tham gia nghiên cứu thực tế, hội thảo khoa học", "Nghiên cứu", "Năm 3" },
                    { 8, "Viết đề tài nghiên cứu, tham gia lab, chuẩn bị học cao học", "Nghiên cứu", "Năm 4" },
                    { 9, "Học mỹ thuật cơ bản, lý thuyết màu sắc, nhiếp ảnh cơ bản", "Nghệ thuật", "Năm 1" },
                    { 10, "Học thiết kế đồ họa, làm dự án cá nhân sáng tạo", "Nghệ thuật", "Năm 2" },
                    { 11, "Học dựng phim, thiết kế giao diện người dùng (UI/UX)", "Nghệ thuật", "Năm 3" },
                    { 12, "Triển lãm cá nhân, làm portfolio, thực tập tại công ty thiết kế", "Nghệ thuật", "Năm 4" },
                    { 13, "Học kỹ năng giao tiếp, tâm lý học, làm việc nhóm", "Xã hội", "Năm 1" },
                    { 14, "Học quản lý giáo dục, tổ chức sự kiện, cố vấn học tập", "Xã hội", "Năm 2" },
                    { 15, "Tham gia CLB, hướng dẫn viên, công tác xã hội", "Xã hội", "Năm 3" },
                    { 16, "Thực tập tại các tổ chức xã hội, lên kế hoạch đào tạo", "Xã hội", "Năm 4" },
                    { 17, "Học quản trị kinh doanh, tư duy phản biện, kỹ năng bán hàng", "Doanh nhân", "Năm 1" },
                    { 18, "Học marketing, tài chính căn bản, quản lý dự án", "Doanh nhân", "Năm 2" },
                    { 19, "Thực hành khởi nghiệp, pitching ý tưởng, quản trị nhân sự", "Doanh nhân", "Năm 3" },
                    { 20, "Thực tập tại doanh nghiệp, triển khai dự án kinh doanh thật", "Doanh nhân", "Năm 4" },
                    { 21, "Học tin học văn phòng, nguyên lý kế toán, hành chính căn bản", "Công sở", "Năm 1" },
                    { 22, "Học kế toán tài chính, nghiệp vụ hành chính, quy trình văn thư", "Công sở", "Năm 2" },
                    { 23, "Thực hành quản trị hồ sơ, kỹ năng viết văn bản hành chính", "Công sở", "Năm 3" },
                    { 24, "Thực tập tại văn phòng, học phần mềm quản lý công việc", "Công sở", "Năm 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningPathSteps");
        }
    }
}
