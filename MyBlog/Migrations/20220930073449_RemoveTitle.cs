using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Migrations
{
    public partial class RemoveTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblArticle_ArticleId",
                table: "tblUser");

            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_ArticleId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "tblArticle");

            migrationBuilder.CreateTable(
                name: "tblArticleTag",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblArticleTag", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_tblArticleTag_tblArticle_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "tblArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblArticleTag_tblTag_TagId",
                        column: x => x.TagId,
                        principalTable: "tblTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblrticleLiker",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikeAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblrticleLiker", x => new { x.ArticleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_tblrticleLiker_tblArticle_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "tblArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblrticleLiker_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblArticleTag_TagId",
                table: "tblArticleTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_tblrticleLiker_UserId",
                table: "tblrticleLiker",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblArticleTag");

            migrationBuilder.DropTable(
                name: "tblrticleLiker");

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "tblUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "tblArticle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArticlesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.ArticlesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ArticleTag_tblArticle_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "tblArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_tblTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "tblTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_ArticleId",
                table: "tblUser",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagsId",
                table: "ArticleTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblArticle_ArticleId",
                table: "tblUser",
                column: "ArticleId",
                principalTable: "tblArticle",
                principalColumn: "Id");
        }
    }
}
