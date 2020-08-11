    using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class UpdateComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "ArticleComment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ArticleComment",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 11, 11, 40, 39, 514, DateTimeKind.Local).AddTicks(4771), false, new DateTime(2020, 8, 11, 11, 40, 39, 514, DateTimeKind.Local).AddTicks(4278) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "ArticleComment");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ArticleComment");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 11, 11, 36, 27, 840, DateTimeKind.Local).AddTicks(6496), (short)0, new DateTime(2020, 8, 11, 11, 36, 27, 840, DateTimeKind.Local).AddTicks(5998) });
        }
    }
}
