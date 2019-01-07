using Microsoft.EntityFrameworkCore.Migrations;

namespace MumsBlog.Data.Migrations
{
    public partial class Refresh3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "BlogPosts",
                newName: "PostTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostTitle",
                table: "BlogPosts",
                newName: "Title");
        }
    }
}
