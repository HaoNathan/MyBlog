using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class UpdateLeaveMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "LeaveMessage",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "LeaveMessage",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 11, 14, 0, 38, 14, DateTimeKind.Local).AddTicks(2271), false, new DateTime(2020, 8, 11, 14, 0, 38, 14, DateTimeKind.Local).AddTicks(1567) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "LeaveMessage");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "LeaveMessage");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 11, 11, 55, 45, 761, DateTimeKind.Local).AddTicks(2855), (short)0, new DateTime(2020, 8, 11, 11, 55, 45, 761, DateTimeKind.Local).AddTicks(2305) });
        }
    }
}
