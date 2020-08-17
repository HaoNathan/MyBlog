using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class createReplyMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReplyMessage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CommentId = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyMessage", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 16, 11, 3, 45, 367, DateTimeKind.Local).AddTicks(1802), false, new DateTime(2020, 8, 16, 11, 3, 45, 367, DateTimeKind.Local).AddTicks(1294) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReplyMessage");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "bbdee09c-089b-4d30-bece-44df5923716c",
                columns: new[] { "CreateTime", "IsRemove", "UpdateTime" },
                values: new object[] { new DateTime(2020, 8, 16, 10, 59, 56, 782, DateTimeKind.Local).AddTicks(2672), (short)0, new DateTime(2020, 8, 16, 10, 59, 56, 782, DateTimeKind.Local).AddTicks(2000) });
        }
    }
}
