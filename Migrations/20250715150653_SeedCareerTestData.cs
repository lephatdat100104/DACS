using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DACS.Migrations
{
    /// <inheritdoc />
    public partial class SeedCareerTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CareerQuestions",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { 1, "Bạn thích làm việc kiểu nào?" },
                    { 2, "Bạn yêu thích hoạt động nào nhất?" },
                    { 3, "Bạn thường giỏi việc gì hơn?" },
                    { 4, "Bạn thích môi trường làm việc như thế nào?" },
                    { 5, "Khi làm việc nhóm, bạn thường đảm nhận vai trò gì?" },
                    { 6, "Môn học bạn thích nhất thời phổ thông là?" },
                    { 7, "Bạn đánh giá bản thân là người thế nào?" },
                    { 8, "Nếu có thời gian rảnh, bạn sẽ chọn làm gì?" },
                    { 9, "Bạn muốn được công nhận vì điều gì?" },
                    { 10, "Bạn thích giải quyết vấn đề bằng cách nào?" }
                });

            migrationBuilder.InsertData(
                table: "CareerOptions",
                columns: new[] { "Id", "CareerQuestionId", "Text", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Sáng tạo nội dung, thiết kế", "Sáng tạo" },
                    { 2, 1, "Sửa chữa, vận hành máy móc", "Kỹ thuật" },
                    { 3, 1, "Giúp đỡ, lắng nghe người khác", "Xã hội" },
                    { 4, 2, "Vẽ tranh, viết truyện, dựng video", "Sáng tạo" },
                    { 5, 2, "Lắp ráp thiết bị, thử nghiệm kỹ thuật", "Kỹ thuật" },
                    { 6, 2, "Tổ chức sự kiện, hỗ trợ cộng đồng", "Xã hội" },
                    { 7, 3, "Nghệ thuật, ngôn ngữ, tưởng tượng", "Sáng tạo" },
                    { 8, 3, "Tính toán, phân tích, logic", "Kỹ thuật" },
                    { 9, 3, "Giao tiếp, kết nối và chia sẻ", "Xã hội" },
                    { 10, 4, "Tự do, linh hoạt, không gò bó", "Sáng tạo" },
                    { 11, 4, "Kỹ luật, có hệ thống", "Kỹ thuật" },
                    { 12, 4, "Tập thể, có tính tương tác cao", "Xã hội" },
                    { 13, 5, "Ý tưởng, định hướng sáng tạo", "Sáng tạo" },
                    { 14, 5, "Xử lý kỹ thuật, kỹ năng cụ thể", "Kỹ thuật" },
                    { 15, 5, "Kết nối nhóm, tạo không khí", "Xã hội" },
                    { 16, 6, "Văn, nghệ thuật", "Sáng tạo" },
                    { 17, 6, "Toán, Tin học, Lý", "Kỹ thuật" },
                    { 18, 6, "Sử, Địa, Giáo dục công dân", "Xã hội" },
                    { 19, 7, "Sáng tạo, bay bổng", "Sáng tạo" },
                    { 20, 7, "Chi tiết, chính xác", "Kỹ thuật" },
                    { 21, 7, "Thấu cảm, nhiệt tình", "Xã hội" },
                    { 22, 8, "Tạo video/TikTok/Youtube", "Sáng tạo" },
                    { 23, 8, "Xem công nghệ mới", "Kỹ thuật" },
                    { 24, 8, "Tham gia nhóm cộng đồng", "Xã hội" },
                    { 25, 9, "Tác phẩm nghệ thuật, ý tưởng", "Sáng tạo" },
                    { 26, 9, "Giải pháp kỹ thuật, lập trình", "Kỹ thuật" },
                    { 27, 9, "Tác động tích cực đến người khác", "Xã hội" },
                    { 28, 10, "Suy nghĩ sáng tạo, đưa ra ý tưởng", "Sáng tạo" },
                    { 29, 10, "Áp dụng công nghệ, phân tích", "Kỹ thuật" },
                    { 30, 10, "Trao đổi, hỏi ý kiến người khác", "Xã hội" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CareerOptions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CareerQuestions",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
