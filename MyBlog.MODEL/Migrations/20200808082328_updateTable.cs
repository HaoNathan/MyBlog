using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Content",
                table: "Articles",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "CreateTime", "IsRemove", "Name", "Password", "UpdateTime" },
                values: new object[] { "bbdee09c-089b-4d30-bece-44df5923716c", new DateTime(2020, 8, 8, 16, 23, 28, 629, DateTimeKind.Local).AddTicks(5538), false, "stackOverflow", "throwNewException", new DateTime(2020, 8, 8, 16, 23, 28, 628, DateTimeKind.Local).AddTicks(5555) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");
        }
    }
}
