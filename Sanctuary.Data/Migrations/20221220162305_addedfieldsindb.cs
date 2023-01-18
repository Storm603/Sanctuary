using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sanctuary.Data.Migrations
{
    public partial class addedfieldsindb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a7336a9-6b24-4ac4-bd85-7c17f034b013");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e5f232a-aa00-4ae6-9836-834f9a51c48d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "726d15c4-11e2-4b6d-a31c-583f73234248");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d85271-4520-4df4-91a2-9529d1cc9e67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a661b1f-138b-4ece-965c-3ffa291cecf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903fd5c2-90e0-4292-9212-7fe6ff67a9e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d7d16f5-aed1-4791-8226-84c52afbfba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f38c71c-b96f-4a48-9d3a-d6ff79a47918");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b1600a-88a5-40ed-bc80-245f2b844c9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2044d0e-dd24-4d5d-a23b-310aa2123a7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d82a183e-cd82-49f3-9c41-1c64266edadd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffb4a152-4afc-42d1-9fe8-163a6398ed8f");

            migrationBuilder.AddColumn<int>(
                name: "HospitalizedPetCagedNumber",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppointmentNumber",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "HospitalizedPetCagedNumber",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "AppointmentNumber",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a7336a9-6b24-4ac4-bd85-7c17f034b013", "13d5c700-1032-4e04-8bce-5f769a496dd5", "Manager", null },
                    { "1e5f232a-aa00-4ae6-9836-834f9a51c48d", "5ed3c39e-ed12-40b8-a592-e4fc8e999664", "Ophthalmologist", null },
                    { "726d15c4-11e2-4b6d-a31c-583f73234248", "4b074c5d-0e07-4acf-8be4-d5a2cb66ed69", "Administrator", null },
                    { "82d85271-4520-4df4-91a2-9529d1cc9e67", "e3d37521-8bf7-4adb-a56c-0151ad4cfa5f", "Emergency and Critical Care Specialist", null },
                    { "8a661b1f-138b-4ece-965c-3ffa291cecf1", "8f94de66-b847-4c08-bf0b-4607c3241774", "User", null },
                    { "903fd5c2-90e0-4292-9212-7fe6ff67a9e8", "314d35b3-fbab-49f3-a26f-92903dd73c25", "Dentist", null },
                    { "9d7d16f5-aed1-4791-8226-84c52afbfba5", "ddef65c0-0e1f-46eb-8d26-eda2a279bce7", "Dentist", null },
                    { "9f38c71c-b96f-4a48-9d3a-d6ff79a47918", "07fa1fbc-8e49-49a2-91f3-748a51f94e16", "Toxicologist", null },
                    { "c6b1600a-88a5-40ed-bc80-245f2b844c9b", "402259cc-7196-41b4-a478-9eef6c08d272", "Behaviorist", null },
                    { "d2044d0e-dd24-4d5d-a23b-310aa2123a7b", "3152967c-e011-42ba-a1dd-b8d750e2a089", "Surgery", null },
                    { "d82a183e-cd82-49f3-9c41-1c64266edadd", "0060ec0f-11b6-4c7c-9606-4137bb67fd6a", "Common Veterinary", null },
                    { "ffb4a152-4afc-42d1-9fe8-163a6398ed8f", "6029695c-d346-46d0-8e02-800f98adedde", "Dermatologist", null }
                });
        }
    }
}
