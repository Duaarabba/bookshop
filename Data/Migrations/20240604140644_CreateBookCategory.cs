using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookshop.Data.Migrations
{
    public partial class CreateBookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authers_AutherID",
                        column: x => x.AutherID,
                        principalTable: "Authers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategorys",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategorys", x => new { x.CategoryId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookCategorys_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategorys_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategorys_BookId",
                table: "BookCategorys",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AutherID",
                table: "Books",
                column: "AutherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategorys");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
