using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBestQuiz.Migrations
{
    public partial class AddThemeToDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Theme_CategoryId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_CategoryId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Quiz");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_ThemeName",
                table: "Quiz",
                column: "ThemeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Theme_ThemeName",
                table: "Quiz",
                column: "ThemeName",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Theme_ThemeName",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_ThemeName",
                table: "Quiz");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Quiz",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_CategoryId",
                table: "Quiz",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Theme_CategoryId",
                table: "Quiz",
                column: "CategoryId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
