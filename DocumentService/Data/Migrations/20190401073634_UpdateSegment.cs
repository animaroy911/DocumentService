 using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentService.Data.Migrations
{
    public partial class UpdateSegment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Segment",
                newName: "Header");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Segment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Segment");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "Segment",
                newName: "Value");
        }
    }
}
