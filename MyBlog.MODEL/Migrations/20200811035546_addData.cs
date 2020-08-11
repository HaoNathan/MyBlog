using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "CreateTime", "IsRemove", "Name", "Password", "UpdateTime" },
                values: new object[] { "bbdee09c-089b-4d30-bece-44df5923716c", new DateTime(2020, 8, 11, 11, 55, 45, 761, DateTimeKind.Local).AddTicks(2855), false, "stackOverflow", "throwNewException", new DateTime(2020, 8, 11, 11, 55, 45, 761, DateTimeKind.Local).AddTicks(2305) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c");
        }
    }
}
