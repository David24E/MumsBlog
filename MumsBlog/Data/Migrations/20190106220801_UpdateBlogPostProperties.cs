using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MumsBlog.Data.Migrations
{
    public partial class UpdateBlogPostProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateAdded",
                table: "BlogPosts",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "BlogPosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "BlogPosts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
