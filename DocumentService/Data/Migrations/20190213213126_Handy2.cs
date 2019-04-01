using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentService.Data.Migrations
{
    public partial class Handy2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskName = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberService_JobTypeID",
                table: "MemberService",
                column: "JobTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberService_JobType_JobTypeID",
                table: "MemberService",
                column: "JobTypeID",
                principalTable: "JobType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberService_JobType_JobTypeID",
                table: "MemberService");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropIndex(
                name: "IX_MemberService_JobTypeID",
                table: "MemberService");
        }
    }
}
