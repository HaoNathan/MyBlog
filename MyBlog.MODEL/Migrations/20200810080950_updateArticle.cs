using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class updateArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Content",
                table: "Articles",
                type: "MEDIUMBLOB",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Articles",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 10, 16, 9, 49, 793, DateTimeKind.Local).AddTicks(3773), false, new DateTime(2020, 8, 10, 16, 9, 49, 793, DateTimeKind.Local).AddTicks(3257) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Articles");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Content",
                table: "Articles",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "MEDIUMBLOB");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 8, 16, 23, 28, 629, DateTimeKind.Local).AddTicks(5538), (short)0, new DateTime(2020, 8, 8, 16, 23, 28, 628, DateTimeKind.Local).AddTicks(5555) });
        }
    }
}
