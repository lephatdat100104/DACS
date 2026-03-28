using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DACS.Migrations
{
    /// <inheritdoc />
    public partial class CreateCareerSuggestionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareerSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuggestedMajors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerSuggestions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CareerSuggestions",
                columns: new[] { "Id", "CareerType", "Resources", "SuggestedMajors" },
                values: new object[,]
                {
                    { 1, "Kỹ thuật", "https://www.freecodecamp.org/, https://viblo.asia/, Sách 'Cấu trúc dữ liệu và giải thuật'", "Công nghệ thông tin, Kỹ thuật phần mềm, Cơ điện tử" },
                    { 2, "Sáng tạo", "https://www.canva.com/learn/, https://www.behance.net/, Sách 'Thiết kế ý tưởng sáng tạo'", "Thiết kế đồ họa, Kiến trúc, Truyền thông đa phương tiện" },
                    { 3, "Xã hội", "https://moet.gov.vn/, Sách 'Tâm lý học đại cương', https://www.edx.org/", "Luật, Quản trị nhân lực, Giáo dục học" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerSuggestions");
        }
    }
}
