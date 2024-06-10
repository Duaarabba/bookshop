using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookshop.Data.Migrations
{
    public partial class editToBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgURL",
                table: "Books",
                newName: "IMGurl");

            migrationBuilder.AlterColumn<string>(
                name: "IMGurl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IMGurl",
                table: "Books",
                newName: "ImgURL");

            migrationBuilder.AlterColumn<string>(
                name: "ImgURL",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
