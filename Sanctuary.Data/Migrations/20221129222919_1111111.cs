using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sanctuary.Data.Migrations
{
    public partial class _1111111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MT_Clinic_Addresses_Addresses_AddressId",
                table: "MT_Clinic_Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MT_Clinic_Addresses_Clinics_ClinicId",
                table: "MT_Clinic_Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MT_Clinic_Addresses",
                table: "MT_Clinic_Addresses");

            migrationBuilder.RenameTable(
                name: "MT_Clinic_Addresses",
                newName: "MtClinicAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_MT_Clinic_Addresses_ClinicId",
                table: "MtClinicAddresses",
                newName: "IX_MtClinicAddresses_ClinicId");

            migrationBuilder.RenameIndex(
                name: "IX_MT_Clinic_Addresses_AddressId",
                table: "MtClinicAddresses",
                newName: "IX_MtClinicAddresses_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MtClinicAddresses",
                table: "MtClinicAddresses",
                columns: new[] { "AddressId", "ClinicId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MtClinicAddresses_Addresses_AddressId",
                table: "MtClinicAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MtClinicAddresses_Clinics_ClinicId",
                table: "MtClinicAddresses",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MtClinicAddresses_Addresses_AddressId",
                table: "MtClinicAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MtClinicAddresses_Clinics_ClinicId",
                table: "MtClinicAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MtClinicAddresses",
                table: "MtClinicAddresses");

            migrationBuilder.RenameTable(
                name: "MtClinicAddresses",
                newName: "MT_Clinic_Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_MtClinicAddresses_ClinicId",
                table: "MT_Clinic_Addresses",
                newName: "IX_MT_Clinic_Addresses_ClinicId");

            migrationBuilder.RenameIndex(
                name: "IX_MtClinicAddresses_AddressId",
                table: "MT_Clinic_Addresses",
                newName: "IX_MT_Clinic_Addresses_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MT_Clinic_Addresses",
                table: "MT_Clinic_Addresses",
                columns: new[] { "AddressId", "ClinicId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MT_Clinic_Addresses_Addresses_AddressId",
                table: "MT_Clinic_Addresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MT_Clinic_Addresses_Clinics_ClinicId",
                table: "MT_Clinic_Addresses",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
