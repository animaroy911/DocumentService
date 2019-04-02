using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentService.Data.Migrations
{
    public partial class AddBook4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segment_Book_BookId",
                table: "Segment");

            migrationBuilder.DropIndex(
                name: "IX_Segment_BookId",
                table: "Segment");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Segment");

            migrationBuilder.AddColumn<string>(
                name: "SegmentIdsString",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SegmentIdsString",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Segment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Segment_BookId",
                table: "Segment",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Segment_Book_BookId",
                table: "Segment",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
