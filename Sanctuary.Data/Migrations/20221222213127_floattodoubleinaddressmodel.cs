using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sanctuary.Data.Migrations
{
    public partial class floattodoubleinaddressmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b07589c-14b8-4293-aee4-6ffa86a661a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c336301-8e11-47b8-aae1-336cd7f66fa5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40fdf9a6-f549-4f31-ab17-ff45a454054d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "474ba1ae-635d-4b22-ad78-520fc34ac0b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ff651ba-1f60-42c4-9681-148a6ce74a75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b8b6a1-e8ff-43b2-8adf-5e3012dd8e67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "976b2811-e1f7-41b6-9fd7-90330256d984");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5b4db2f-1d1c-4e90-8143-a8092cff6c3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1686af4-c38c-4873-bcd8-f89ae295ba68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5bc91c4-bbac-4b90-b6b2-3ca255222448");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8a956e9-6e92-45f0-8b7e-2e4cc878c1b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7fc9f85-6321-4b41-a33f-3adae252b576");

            migrationBuilder.AlterColumn<double>(
                name: "lon",
                table: "Addresses",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "lat",
                table: "Addresses",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36ca2e4d-1197-40d3-8217-a23a4ce44e8c", "e2a52f32-f09a-4a83-800d-b0d6827a639a", "Manager", null },
                    { "4c32e372-9e57-4705-b54c-ce066ed10e6c", "b0efa159-e96c-4fe2-82dd-9d25ac24d023", "Administrator", null },
                    { "4f40ee04-39d4-4e0e-bbe6-b82fabce7928", "d60dccdf-74d3-4006-8ba3-86e2ab3ff8d3", "Dermatologist", null },
                    { "4f97e221-670b-4380-bf7a-122407878bfd", "88f7cae2-9898-4042-957d-a6d78e4df98c", "Dentist", null },
                    { "79e731ef-707d-48c8-818e-055f87a5453a", "919f7cb7-c955-4ae9-95b3-83d6748e3a4b", "Emergency and Critical Care Specialist", null },
                    { "7c76583f-56d6-41d9-8bb0-171019d76845", "55ae3bf4-1ddb-46ac-b8b6-1a68431eaf17", "User", null },
                    { "9162824c-bac8-4e43-96f0-679ae08c9d91", "b62ddc96-9cd6-4d4f-a04e-78886bebba45", "Behaviorist", null },
                    { "bddcb0b7-f72e-44d5-ba28-1744cd157059", "0c9eb24a-3e90-4203-aa21-bb1981aad03c", "Toxicologist", null },
                    { "c5ea98d9-98f9-411f-8802-14a296d8d22e", "5396cfa4-8200-4af5-a68f-8da3a5ce606b", "Common Veterinary", null },
                    { "dbe3c8a0-3b0b-4a5d-b24c-65557170ffcc", "6688d71e-e8b3-487a-964d-4bc47d9b2b00", "Ophthalmologist", null },
                    { "ed13e7eb-8b01-4329-b1a5-adfa3ddf3a6b", "84c3e505-e81d-47aa-b7f7-c0850cb8ed38", "Surgery", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ca2e4d-1197-40d3-8217-a23a4ce44e8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c32e372-9e57-4705-b54c-ce066ed10e6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f40ee04-39d4-4e0e-bbe6-b82fabce7928");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f97e221-670b-4380-bf7a-122407878bfd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79e731ef-707d-48c8-818e-055f87a5453a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c76583f-56d6-41d9-8bb0-171019d76845");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9162824c-bac8-4e43-96f0-679ae08c9d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bddcb0b7-f72e-44d5-ba28-1744cd157059");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5ea98d9-98f9-411f-8802-14a296d8d22e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe3c8a0-3b0b-4a5d-b24c-65557170ffcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed13e7eb-8b01-4329-b1a5-adfa3ddf3a6b");

            migrationBuilder.AlterColumn<float>(
                name: "lon",
                table: "Addresses",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "lat",
                table: "Addresses",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b07589c-14b8-4293-aee4-6ffa86a661a3", "30e3b47c-9c8e-4640-b603-fbc8f9aad306", "Ophthalmologist", null },
                    { "2c336301-8e11-47b8-aae1-336cd7f66fa5", "6e257c53-9595-4568-a4c9-3d4f300ab80f", "User", null },
                    { "40fdf9a6-f549-4f31-ab17-ff45a454054d", "a269c604-fa0a-4941-b0af-860b930b993d", "Manager", null },
                    { "474ba1ae-635d-4b22-ad78-520fc34ac0b0", "c22b6682-cf86-4ee9-bc3b-0a8c9eabfc03", "Surgery", null },
                    { "4ff651ba-1f60-42c4-9681-148a6ce74a75", "c48ec5c9-06d5-470f-90b8-1d13b04a2dbf", "Dermatologist", null },
                    { "54b8b6a1-e8ff-43b2-8adf-5e3012dd8e67", "43eaebda-e380-4e90-94ec-97d27ef5a8e1", "Behaviorist", null },
                    { "976b2811-e1f7-41b6-9fd7-90330256d984", "5fcbddd1-205d-4d45-a2c7-69785759a97d", "Toxicologist", null },
                    { "a5b4db2f-1d1c-4e90-8143-a8092cff6c3c", "720f3e9d-bdc5-4ff0-8723-8e2363a6e759", "Administrator", null },
                    { "b1686af4-c38c-4873-bcd8-f89ae295ba68", "1e58dce9-6905-42eb-866c-02fad9acdbcd", "Common Veterinary", null },
                    { "c5bc91c4-bbac-4b90-b6b2-3ca255222448", "b61fe04f-fcbb-489f-a76c-5c7441dcc273", "Dentist", null },
                    { "c8a956e9-6e92-45f0-8b7e-2e4cc878c1b0", "771cdd35-fdfc-4b0a-b207-3a1af79a3aa2", "Dentist", null },
                    { "f7fc9f85-6321-4b41-a33f-3adae252b576", "21802f0e-57d0-4e42-a74b-17e137279ab6", "Emergency and Critical Care Specialist", null }
                });
        }
    }
}
