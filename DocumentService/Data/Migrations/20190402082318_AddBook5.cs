using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentService.Data.Migrations
{
    public partial class AddBook5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Book");
        }
    }
}
