using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBestQuiz.Migrations
{
    public partial class ThemeNameToThemeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Theme_ThemeName",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "ThemeName",
                table: "Theme",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ThemeName",
                table: "Quiz",
                newName: "ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_ThemeName",
                table: "Quiz",
                newName: "IX_Quiz_ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Theme_ThemeId",
                table: "Quiz",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Theme_ThemeId",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Theme",
                newName: "ThemeName");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Quiz",
                newName: "ThemeName");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_ThemeId",
                table: "Quiz",
                newName: "IX_Quiz_ThemeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Theme_ThemeName",
                table: "Quiz",
                column: "ThemeName",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
