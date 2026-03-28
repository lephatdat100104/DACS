using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DACS.Migrations
{
    /// <inheritdoc />
    public partial class SeedFinalYearQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinalYearQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalYearQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalYearTestResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakenAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalYearTestResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalYearAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalYearAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalYearAnswers_FinalYearQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "FinalYearQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FinalYearQuestions",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { 1, "Bạn đã có định hướng nghề nghiệp sau khi ra trường chưa?" },
                    { 2, "Bạn đã từng tham gia thực tập hoặc dự án thực tế chưa?" },
                    { 3, "Bạn đã chuẩn bị CV xin việc chưa?" },
                    { 4, "Bạn có tham gia các hoạt động ngoại khóa hoặc CLB không?" },
                    { 5, "Bạn có chứng chỉ ngoại ngữ (TOEIC/IELTS...) chưa?" },
                    { 6, "Bạn có kỹ năng tin học văn phòng (Word, Excel, PowerPoint) ở mức nào?" },
                    { 7, "Bạn có tham gia các workshop / seminar nghề nghiệp không?" },
                    { 8, "Bạn có tự tin khi tham gia phỏng vấn không?" },
                    { 9, "Bạn có định hướng học lên cao học hoặc học thêm chứng chỉ chuyên ngành không?" },
                    { 10, "Bạn có kế hoạch phát triển kỹ năng mềm (teamwork, giao tiếp, quản lý thời gian) không?" }
                });

            migrationBuilder.InsertData(
                table: "FinalYearAnswers",
                columns: new[] { "Id", "Content", "QuestionId", "Score" },
                values: new object[,]
                {
                    { 1, "Rõ ràng", 1, 3 },
                    { 2, "Tạm thời", 1, 2 },
                    { 3, "Chưa có", 1, 1 },
                    { 4, "Có", 2, 3 },
                    { 5, "Dự định có", 2, 2 },
                    { 6, "Chưa", 2, 1 },
                    { 7, "Đã hoàn chỉnh", 3, 3 },
                    { 8, "Có nhưng chưa chỉnh chu", 3, 2 },
                    { 9, "Chưa có", 3, 1 },
                    { 10, "Có, thường xuyên", 4, 3 },
                    { 11, "Thỉnh thoảng", 4, 2 },
                    { 12, "Không", 4, 1 },
                    { 13, "Có", 5, 3 },
                    { 14, "Đang học để thi", 5, 2 },
                    { 15, "Chưa", 5, 1 },
                    { 16, "Thành thạo", 6, 3 },
                    { 17, "Trung bình", 6, 2 },
                    { 18, "Yếu", 6, 1 },
                    { 19, "Có, thường xuyên", 7, 3 },
                    { 20, "Đôi khi", 7, 2 },
                    { 21, "Không bao giờ", 7, 1 },
                    { 22, "Rất tự tin", 8, 3 },
                    { 23, "Bình thường", 8, 2 },
                    { 24, "Chưa tự tin", 8, 1 },
                    { 25, "Có kế hoạch rõ ràng", 9, 3 },
                    { 26, "Đang cân nhắc", 9, 2 },
                    { 27, "Chưa nghĩ tới", 9, 1 },
                    { 28, "Có kế hoạch & đang rèn luyện", 10, 3 },
                    { 29, "Có nghe nhưng chưa áp dụng", 10, 2 },
                    { 30, "Chưa quan tâm", 10, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalYearAnswers_QuestionId",
                table: "FinalYearAnswers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalYearAnswers");

            migrationBuilder.DropTable(
                name: "FinalYearTestResults");

            migrationBuilder.DropTable(
                name: "FinalYearQuestions");
        }
    }
}
