using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sanctuary.Data.Migrations
{
    public partial class roleseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
