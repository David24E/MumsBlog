using Microsoft.EntityFrameworkCore.Migrations;

namespace MumsBlog.Data.Migrations
{
    public partial class Refresh1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "BlogPosts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BlogPosts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_BlogCategories_CategoryId",
                table: "BlogPosts",
                column: "CategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_BlogCategories_CategoryId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "BlogPosts",
                nullable: true);
        }
    }
}
