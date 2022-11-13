using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sanctuary.Data.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_ReplacedById",
                table: "ClinicStaffLeave");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_ReplacedById",
                table: "ClinicStaffLeave",
                column: "ReplacedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_ReplacedById",
                table: "ClinicStaffLeave");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_ReplacedById",
                table: "ClinicStaffLeave",
                column: "ReplacedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
