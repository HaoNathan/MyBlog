using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.MODEL.Migrations
{
    public partial class createTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveMessage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PictureWall",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureWall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ArticleCategoryId = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleCategory_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticleCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleComment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsRemove = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArticleId = table.Column<string>(type: "char(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComment_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_ArticleId",
                table: "ArticleComment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ArticleComment");

            migrationBuilder.DropTable(
                name: "LeaveMessage");

            migrationBuilder.DropTable(
                name: "PictureWall");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleCategory");
        }
    }
}
