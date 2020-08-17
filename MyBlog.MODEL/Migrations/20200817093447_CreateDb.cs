using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 17, 17, 34, 47, 423, DateTimeKind.Local).AddTicks(1668), false, new DateTime(2020, 8, 17, 17, 34, 47, 423, DateTimeKind.Local).AddTicks(1153) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 16, 11, 3, 45, 367, DateTimeKind.Local).AddTicks(1802), (short)0, new DateTime(2020, 8, 16, 11, 3, 45, 367, DateTimeKind.Local).AddTicks(1294) });
        }
    }
}
