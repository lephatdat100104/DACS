using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DACS.Migrations
{
    /// <inheritdoc />
    public partial class AddUniversitySuggestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversitySuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DominantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversitySuggestions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UniversitySuggestions",
                columns: new[] { "Id", "DominantType", "Major", "UniversityName", "Website" },
                values: new object[,]
                {
                    { 1, "Kỹ thuật", "Công nghệ thông tin", "ĐH Bách Khoa TP.HCM", "https://hcmut.edu.vn" },
                    { 2, "Kỹ thuật", "Kỹ thuật phần mềm", "ĐH Công Nghệ Thông Tin", "https://uit.edu.vn" },
                    { 3, "Sáng tạo", "Thiết kế đồ họa", "ĐH Mỹ Thuật TP.HCM", "http://hcmufa.edu.vn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversitySuggestions");
        }
    }
}
