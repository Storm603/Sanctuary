using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sanctuary.Data.Migrations
{
    public partial class _11111111111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ClientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BaseUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ClinicStaffUser_BaseUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicStaffUser_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_ReplacedById",
                table: "ClinicStaffLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_RequestedById",
                table: "ClinicStaffLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_ToId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_ClientUserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BaseUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClinicStaffUser_BaseUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClinicStaffUser_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BaseUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClinicStaffUser_BaseUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClinicStaffUser_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TotalPaidDaysLeave",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ClientUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientUsers_AspNetUsers_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientUsers_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClinicStaffUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPaidDaysLeave = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicStaffUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicStaffUsers_AspNetUsers_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicStaffUsers_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientUsers_BaseUserId",
                table: "ClientUsers",
                column: "BaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientUsers_ClinicId",
                table: "ClientUsers",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicStaffUsers_BaseUserId",
                table: "ClinicStaffUsers",
                column: "BaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicStaffUsers_ClinicId",
                table: "ClinicStaffUsers",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ClientUsers_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "ClientUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ClinicStaffUsers_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "ClinicStaffUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicStaffLeave_ClinicStaffUsers_ReplacedById",
                table: "ClinicStaffLeave",
                column: "ReplacedById",
                principalTable: "ClinicStaffUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicStaffLeave_ClinicStaffUsers_RequestedById",
                table: "ClinicStaffLeave",
                column: "RequestedById",
                principalTable: "ClinicStaffUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ClientUsers_ToId",
                table: "Invoices",
                column: "ToId",
                principalTable: "ClientUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_ClientUsers_ClientUserId",
                table: "Pets",
                column: "ClientUserId",
                principalTable: "ClientUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ClientUsers_ClientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ClinicStaffUsers_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicStaffLeave_ClinicStaffUsers_ReplacedById",
                table: "ClinicStaffLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicStaffLeave_ClinicStaffUsers_RequestedById",
                table: "ClinicStaffLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ClientUsers_ToId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_ClientUsers_ClientUserId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "ClientUsers");

            migrationBuilder.DropTable(
                name: "ClinicStaffUsers");

            migrationBuilder.AddColumn<string>(
                name: "BaseUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClinicStaffUser_BaseUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClinicStaffUser_ClinicId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalPaidDaysLeave",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BaseUserId",
                table: "AspNetUsers",
                column: "BaseUserId",
                unique: true,
                filter: "[BaseUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClinicStaffUser_BaseUserId",
                table: "AspNetUsers",
                column: "ClinicStaffUser_BaseUserId",
                unique: true,
                filter: "[ClinicStaffUser_BaseUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClinicStaffUser_ClinicId",
                table: "AspNetUsers",
                column: "ClinicStaffUser_ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ClientId",
                table: "Appointments",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_BaseUserId",
                table: "AspNetUsers",
                column: "BaseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ClinicStaffUser_BaseUserId",
                table: "AspNetUsers",
                column: "ClinicStaffUser_BaseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicStaffUser_ClinicId",
                table: "AspNetUsers",
                column: "ClinicStaffUser_ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_ReplacedById",
                table: "ClinicStaffLeave",
                column: "ReplacedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicStaffLeave_AspNetUsers_RequestedById",
                table: "ClinicStaffLeave",
                column: "RequestedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_ToId",
                table: "Invoices",
                column: "ToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_ClientUserId",
                table: "Pets",
                column: "ClientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
