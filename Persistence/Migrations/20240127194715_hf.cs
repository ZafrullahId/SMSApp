using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class hf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("05f181b0-0c2d-4133-bc58-8a528e3dea4f"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("0c821195-f977-40a0-ae38-d5618dbfcae8"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("8de61166-a421-4ff3-856e-e30d55282d91"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6c3e84ab-ec64-4e3a-ba37-3e6be992b996"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c6858114-70ab-4479-b901-3addb6bf1484"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("acee4ef7-9942-4fb6-9e12-2e9d6143222e"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("21a3edc5-ba01-4ddc-a24c-66f4a34788f4"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("2940bd03-b2cf-497c-b815-3c0b520cab84"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("2e3b756f-2aeb-4238-b8a1-f9f7aeaf09dd"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("35ec362f-8ac7-4fa3-91e9-32810779f792"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("36b9736f-3ece-4baa-bd55-6fbcd277ab42"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("40b15367-e456-471b-8d1a-3091d5fad9fe"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("52cec3a6-7f6f-49b2-aeb6-bf0dfe494679"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7e4d0e6f-232b-46c1-b79b-d3b9fec00117"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("901916cf-0703-48a5-9f5c-21d105f694bd"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("90266ade-6e8c-41c9-9e45-a5fa234c17a7"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("aec3de86-6db1-4308-8da2-a4267228df03"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("b9f33710-697b-4e90-a32c-45fa7f503846"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ce39a632-a1e9-4011-a55b-b268729ffc1c"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("d375d3ac-7dec-4cb0-b46c-4d03b844978d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ed11911c-880d-4543-bd98-eee7c4f18ed8"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("f498a5a1-3b06-4ced-aaac-030d33d6399c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("7a945f64-8554-40eb-8523-edb5bd55325d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("69d0fb70-9302-4a1c-858f-b39bb1213e99"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("da21c254-486f-4976-aad5-5d51fd22898f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bb5e0e33-a105-400d-99fe-b6e5f3888982"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26746986-5393-47d6-9667-78c68362158a"));

            migrationBuilder.CreateTable(
                name: "SchoolProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolProfiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "Science", "Science" },
                    { new Guid("86783c47-d156-461f-aa04-81c189be7096"), "Commercial", "Commercial" },
                    { new Guid("ff6c32e0-bcaf-4fbe-affd-9456c2ecdc78"), "Att", "Art" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("6c248d93-b38d-4ef8-8eef-8e942113d756"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7484), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7484), "SSS2", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7484), "SSS2" },
                    { new Guid("7b0baf0f-7a84-4852-8c7a-5e1123e5c8e1"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7487), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7488), "SSS3", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7487), "SSS3" },
                    { new Guid("c88741ec-06cb-4d0b-9d64-633fc6dcda29"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7480), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7481), "SSS1", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7481), "SSS1" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("7108f330-b5d0-4f21-8e2b-1732a5d01e73"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(6418), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(6419), "Oga pata pata", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(6419), "Admin" },
                    { new Guid("a1e8ef0f-0970-400c-be43-46ea5e596843"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7351), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7352), "Student", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7352), "Student" },
                    { new Guid("fe2632e5-30ba-41a5-adbc-615e7e0675c4"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7343), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7345), "Omo ishe", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7345), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "SchoolProfiles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "SchoolFee", "Session", "Term" },
                values: new object[] { new Guid("7906a0a5-4d5b-48c3-8ca8-8e47f8a4f40e"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7613), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7614), false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7614), 200000.00m, "2022/2023", 1 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("4b195694-e28a-4e75-8431-46e8b1f026a5"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7517), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7517), null, "English vocabulary", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7517), "English" },
                    { new Guid("ebb5b755-4b5b-4bc6-bc8c-40abb4df8ecb"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7528), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7529), null, "Biology", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7528), "Biology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "IsProfileComplete", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("c4858e1f-3a78-4dfb-b640-20efb387c6c9"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(6368), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(6381), "Oga@Admin", "Oga@Admin", false, false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(6381), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("6fcaa264-5a56-48c9-87b8-20959f682679"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7436), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7437), false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7437), new Guid("c4858e1f-3a78-4dfb-b640-20efb387c6c9") });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("18e9e88b-93c5-4431-8550-e83cc029c5f5"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7593), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7594), new Guid("ff6c32e0-bcaf-4fbe-affd-9456c2ecdc78"), "IRS", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7594), "IRS" },
                    { new Guid("3b9af27e-9884-46af-a07b-a9fbac172576"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7523), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7523), new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "Chemistry", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7523), "Chemistry" },
                    { new Guid("438bbde6-d449-4962-a385-4adf4e1efc78"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7534), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7535), new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "Further Mathematics", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7534), "Further Mathematics" },
                    { new Guid("5472c5e1-67a8-4019-a629-d6aad6616cac"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7543), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7543), new Guid("86783c47-d156-461f-aa04-81c189be7096"), "Commerce", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7543), "Commerce" },
                    { new Guid("65e50ba5-2d6e-4ce7-be05-8f131e92f056"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7537), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7538), new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "Geography", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7537), "Geography" },
                    { new Guid("7cd96059-0cd2-430a-aec4-21c5470e77cb"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7587), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7588), new Guid("ff6c32e0-bcaf-4fbe-affd-9456c2ecdc78"), "History", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7588), "History" },
                    { new Guid("8c7aaad8-bc26-408c-a5ed-37675b7d5c00"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7590), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7591), new Guid("ff6c32e0-bcaf-4fbe-affd-9456c2ecdc78"), "CRS", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7591), "CRS" },
                    { new Guid("a45c8a3b-3a58-411c-bcc7-0301a1c71dd2"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7540), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7541), new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "Agric Science", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7540), "Agric Science" },
                    { new Guid("acdbc132-8f3c-4502-8f92-8f9887e614e1"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7520), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7520), new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "Physics", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7520), "Physics" },
                    { new Guid("ad95ee73-cdc0-4a00-9bff-d982816d7943"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7546), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7546), new Guid("86783c47-d156-461f-aa04-81c189be7096"), "Account", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7546), "Account" },
                    { new Guid("b73156d5-fb45-4382-9a3b-fc0188088671"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7512), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7513), new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "Mathematics", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7512), "Mathematics" },
                    { new Guid("b9aafd8b-aa0b-435b-bc69-caa219941c68"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7582), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7583), new Guid("ff6c32e0-bcaf-4fbe-affd-9456c2ecdc78"), "Government", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7582), "Government" },
                    { new Guid("d00b4aa5-6aec-4484-81a7-2b124f6c9046"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7531), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7532), new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"), "ICT", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7531), "ICT" },
                    { new Guid("d8b62a2a-25fb-43f1-ba24-a7e29ff10d34"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7596), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7597), new Guid("ff6c32e0-bcaf-4fbe-affd-9456c2ecdc78"), "Literature-in-English", false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7597), "Literature-in-English" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("790ef3e8-7b90-427e-abaf-65c42256bbc9"), 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7460), null, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7461), false, 0, new DateTime(2024, 1, 27, 20, 47, 15, 27, DateTimeKind.Local).AddTicks(7460), new Guid("7108f330-b5d0-4f21-8e2b-1732a5d01e73"), new Guid("c4858e1f-3a78-4dfb-b640-20efb387c6c9") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolProfiles");

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("6c248d93-b38d-4ef8-8eef-8e942113d756"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("7b0baf0f-7a84-4852-8c7a-5e1123e5c8e1"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("c88741ec-06cb-4d0b-9d64-633fc6dcda29"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1e8ef0f-0970-400c-be43-46ea5e596843"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fe2632e5-30ba-41a5-adbc-615e7e0675c4"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("6fcaa264-5a56-48c9-87b8-20959f682679"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("18e9e88b-93c5-4431-8550-e83cc029c5f5"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("3b9af27e-9884-46af-a07b-a9fbac172576"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("438bbde6-d449-4962-a385-4adf4e1efc78"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("4b195694-e28a-4e75-8431-46e8b1f026a5"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("5472c5e1-67a8-4019-a629-d6aad6616cac"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("65e50ba5-2d6e-4ce7-be05-8f131e92f056"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7cd96059-0cd2-430a-aec4-21c5470e77cb"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8c7aaad8-bc26-408c-a5ed-37675b7d5c00"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("a45c8a3b-3a58-411c-bcc7-0301a1c71dd2"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("acdbc132-8f3c-4502-8f92-8f9887e614e1"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ad95ee73-cdc0-4a00-9bff-d982816d7943"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("b73156d5-fb45-4382-9a3b-fc0188088671"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("b9aafd8b-aa0b-435b-bc69-caa219941c68"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("d00b4aa5-6aec-4484-81a7-2b124f6c9046"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("d8b62a2a-25fb-43f1-ba24-a7e29ff10d34"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ebb5b755-4b5b-4bc6-bc8c-40abb4df8ecb"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("790ef3e8-7b90-427e-abaf-65c42256bbc9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7c4ae141-6dcd-457a-959c-08147a016d32"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("86783c47-d156-461f-aa04-81c189be7096"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ff6c32e0-bcaf-4fbe-affd-9456c2ecdc78"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7108f330-b5d0-4f21-8e2b-1732a5d01e73"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4858e1f-3a78-4dfb-b640-20efb387c6c9"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("69d0fb70-9302-4a1c-858f-b39bb1213e99"), "Att", "Art" },
                    { new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "Science", "Science" },
                    { new Guid("da21c254-486f-4976-aad5-5d51fd22898f"), "Commercial", "Commercial" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("05f181b0-0c2d-4133-bc58-8a528e3dea4f"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7586), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7587), "SSS2", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7586), "SSS2" },
                    { new Guid("0c821195-f977-40a0-ae38-d5618dbfcae8"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7580), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7582), "SSS1", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7581), "SSS1" },
                    { new Guid("8de61166-a421-4ff3-856e-e30d55282d91"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7590), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7591), "SSS3", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7591), "SSS3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("6c3e84ab-ec64-4e3a-ba37-3e6be992b996"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7416), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7418), "Omo ishe", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7418), "Teacher" },
                    { new Guid("bb5e0e33-a105-400d-99fe-b6e5f3888982"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(6084), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(6085), "Oga pata pata", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(6085), "Admin" },
                    { new Guid("c6858114-70ab-4479-b901-3addb6bf1484"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7439), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7440), "Student", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7439), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("36b9736f-3ece-4baa-bd55-6fbcd277ab42"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7654), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7655), null, "Biology", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7654), "Biology" },
                    { new Guid("52cec3a6-7f6f-49b2-aeb6-bf0dfe494679"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7637), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7638), null, "English vocabulary", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7638), "English" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "IsProfileComplete", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("26746986-5393-47d6-9667-78c68362158a"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(6027), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(6040), "Oga@Admin", "Oga@Admin", false, false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(6040), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("acee4ef7-9942-4fb6-9e12-2e9d6143222e"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7537), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7538), false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7538), new Guid("26746986-5393-47d6-9667-78c68362158a") });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("21a3edc5-ba01-4ddc-a24c-66f4a34788f4"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7752), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7753), new Guid("69d0fb70-9302-4a1c-858f-b39bb1213e99"), "CRS", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7753), "CRS" },
                    { new Guid("2940bd03-b2cf-497c-b815-3c0b520cab84"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7748), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7749), new Guid("69d0fb70-9302-4a1c-858f-b39bb1213e99"), "History", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7748), "History" },
                    { new Guid("2e3b756f-2aeb-4238-b8a1-f9f7aeaf09dd"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7739), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7740), new Guid("da21c254-486f-4976-aad5-5d51fd22898f"), "Account", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7739), "Account" },
                    { new Guid("35ec362f-8ac7-4fa3-91e9-32810779f792"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7627), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7628), new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "Mathematics", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7627), "Mathematics" },
                    { new Guid("40b15367-e456-471b-8d1a-3091d5fad9fe"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7662), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7663), new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "Further Mathematics", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7663), "Further Mathematics" },
                    { new Guid("7e4d0e6f-232b-46c1-b79b-d3b9fec00117"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7730), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7731), new Guid("da21c254-486f-4976-aad5-5d51fd22898f"), "Commerce", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7731), "Commerce" },
                    { new Guid("901916cf-0703-48a5-9f5c-21d105f694bd"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7645), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7646), new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "Physics", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7645), "Physics" },
                    { new Guid("90266ade-6e8c-41c9-9e45-a5fa234c17a7"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7757), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7758), new Guid("69d0fb70-9302-4a1c-858f-b39bb1213e99"), "IRS", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7758), "IRS" },
                    { new Guid("aec3de86-6db1-4308-8da2-a4267228df03"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7762), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7763), new Guid("69d0fb70-9302-4a1c-858f-b39bb1213e99"), "Literature-in-English", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7762), "Literature-in-English" },
                    { new Guid("b9f33710-697b-4e90-a32c-45fa7f503846"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7666), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7667), new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "Geography", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7667), "Geography" },
                    { new Guid("ce39a632-a1e9-4011-a55b-b268729ffc1c"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7658), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7659), new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "ICT", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7658), "ICT" },
                    { new Guid("d375d3ac-7dec-4cb0-b46c-4d03b844978d"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7672), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7673), new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "Agric Science", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7673), "Agric Science" },
                    { new Guid("ed11911c-880d-4543-bd98-eee7c4f18ed8"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7743), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7744), new Guid("69d0fb70-9302-4a1c-858f-b39bb1213e99"), "Government", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7744), "Government" },
                    { new Guid("f498a5a1-3b06-4ced-aaac-030d33d6399c"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7649), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7650), new Guid("95a20fe8-f023-404b-ab5c-95acfcce298f"), "Chemistry", false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7650), "Chemistry" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("7a945f64-8554-40eb-8523-edb5bd55325d"), 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7555), null, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7556), false, 0, new DateTime(2023, 11, 5, 15, 20, 53, 450, DateTimeKind.Local).AddTicks(7556), new Guid("bb5e0e33-a105-400d-99fe-b6e5f3888982"), new Guid("26746986-5393-47d6-9667-78c68362158a") });
        }
    }
}
