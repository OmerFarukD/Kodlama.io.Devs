using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devs.Persistence.Migrations
{
    public partial class values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Frameworks",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Django" },
                    { 2, 1, "Flask" },
                    { 3, 2, "Spring boot" },
                    { 4, 2, "JSF" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
