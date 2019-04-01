using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentService.Data.Migrations
{
    public partial class Handy1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HandyMember",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AptNum = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZIP = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Tasker = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandyMember", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemberService",
                columns: table => new
                {
                    MemberServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HandyMemberID = table.Column<int>(nullable: false),
                    JobTypeID = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Certificate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberService", x => x.MemberServiceID);
                    table.ForeignKey(
                        name: "FK_MemberService_HandyMember_HandyMemberID",
                        column: x => x.HandyMemberID,
                        principalTable: "HandyMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberService_HandyMemberID",
                table: "MemberService",
                column: "HandyMemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberService");

            migrationBuilder.DropTable(
                name: "HandyMember");
        }
    }
}
