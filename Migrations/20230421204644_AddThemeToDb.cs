using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBestQuiz.Migrations
{
    public partial class AddThemeToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Quiz",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThemeName",
                table: "Quiz",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ThemeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Theme_CategoryId",
                table: "Quiz");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_CategoryId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "ThemeName",
                table: "Quiz");
        }
    }
}
