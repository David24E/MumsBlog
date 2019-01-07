using Microsoft.EntityFrameworkCore.Migrations;

namespace MumsBlog.Data.Migrations
{
    public partial class UpdateBlogPostPropertiesOnceAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BlogPosts",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BlogPosts");
        }
    }
}
