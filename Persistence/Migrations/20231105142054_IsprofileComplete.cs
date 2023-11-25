using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class IsprofileComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("64a92191-a4f5-4708-8e34-ce669f3e2f68"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("80c827ca-e200-4f5e-b33c-1dffcd058481"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("89cd6c56-feef-43e5-8d8f-d408c8837e55"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f765493-93dd-4293-b607-dac9aead7512"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df117905-48c9-42d3-9c9f-e281d16356fe"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("81ee5f30-19cd-4658-bc85-66df402dde15"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("1efb8597-4335-49ae-a2e7-7f5320b18ec3"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("3468ee3f-9226-4714-ac4b-87344b59eaf1"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("3be8be78-2033-411e-8caa-efb1cc56fbc8"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("47000ab0-4246-48ba-b5f8-34743e2a1993"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("59a293c4-d4f3-429b-bf51-26e2477bc98e"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("70380e96-a09c-429a-85a9-9571db64e6a7"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("70ee6712-201f-4802-b66f-13a4c2dc75f4"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("79762c62-34e6-4844-b591-bc7316725c90"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8ecee9e2-470e-4d35-8544-506e946ed473"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("9664541f-5df6-4286-ae23-e94dc656c592"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("9a20fe82-fa3f-4f62-829c-428d4a11719f"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("b9f1161c-78ca-4716-8cf6-6b331ad8dd4f"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("bae98e25-49ec-4957-920c-0b6152fa48b4"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("d299438c-23c0-4adb-b434-02d1ecd56cda"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("e09637a2-c434-4a29-a554-7c3fa6886b0f"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("eb48627f-7252-437a-a04b-ca493c50b24d"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ad22dac-6c70-47d8-9035-03ee4f57e93d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2f76ca48-8044-444b-a965-cd0b5382c911"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8b760327-d4d4-474c-a2a7-028d8e7b2502"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("257a82c2-b0d5-467b-b93b-334ad386be2c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2012a23d-d828-43c2-a92f-296ebfa6afe6"));

            migrationBuilder.AddColumn<bool>(
                name: "IsProfileComplete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsProfileComplete",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2f76ca48-8044-444b-a965-cd0b5382c911"), "Att", "Art" },
                    { new Guid("8b760327-d4d4-474c-a2a7-028d8e7b2502"), "Commercial", "Commercial" },
                    { new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "Science", "Science" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("64a92191-a4f5-4708-8e34-ce669f3e2f68"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3882), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3883), "SSS3", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3882), "SSS3" },
                    { new Guid("80c827ca-e200-4f5e-b33c-1dffcd058481"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3878), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3879), "SSS2", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3878), "SSS2" },
                    { new Guid("89cd6c56-feef-43e5-8d8f-d408c8837e55"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3873), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3874), "SSS1", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3873), "SSS1" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("257a82c2-b0d5-467b-b93b-334ad386be2c"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(2454), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(2454), "Oga pata pata", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(2454), "Admin" },
                    { new Guid("8f765493-93dd-4293-b607-dac9aead7512"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3704), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3705), "Student", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3704), "Student" },
                    { new Guid("df117905-48c9-42d3-9c9f-e281d16356fe"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3696), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3698), "Omo ishe", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3697), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("3be8be78-2033-411e-8caa-efb1cc56fbc8"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3931), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3932), null, "English vocabulary", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3932), "English" },
                    { new Guid("bae98e25-49ec-4957-920c-0b6152fa48b4"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3947), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3948), null, "Biology", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3947), "Biology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("2012a23d-d828-43c2-a92f-296ebfa6afe6"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(2393), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(2406), "Oga@Admin", "Oga@Admin", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(2406), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("81ee5f30-19cd-4658-bc85-66df402dde15"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3806), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3807), false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3806), new Guid("2012a23d-d828-43c2-a92f-296ebfa6afe6") });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("1efb8597-4335-49ae-a2e7-7f5320b18ec3"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3925), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3926), new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "Mathematics", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3926), "Mathematics" },
                    { new Guid("3468ee3f-9226-4714-ac4b-87344b59eaf1"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4023), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4024), new Guid("8b760327-d4d4-474c-a2a7-028d8e7b2502"), "Commerce", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4023), "Commerce" },
                    { new Guid("47000ab0-4246-48ba-b5f8-34743e2a1993"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3939), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3940), new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "Chemistry", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3940), "Chemistry" },
                    { new Guid("59a293c4-d4f3-429b-bf51-26e2477bc98e"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4042), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4043), new Guid("2f76ca48-8044-444b-a965-cd0b5382c911"), "CRS", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4042), "CRS" },
                    { new Guid("70380e96-a09c-429a-85a9-9571db64e6a7"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3951), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3952), new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "ICT", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3951), "ICT" },
                    { new Guid("70ee6712-201f-4802-b66f-13a4c2dc75f4"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4027), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4028), new Guid("8b760327-d4d4-474c-a2a7-028d8e7b2502"), "Account", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4027), "Account" },
                    { new Guid("79762c62-34e6-4844-b591-bc7316725c90"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4031), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4032), new Guid("2f76ca48-8044-444b-a965-cd0b5382c911"), "Government", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4032), "Government" },
                    { new Guid("8ecee9e2-470e-4d35-8544-506e946ed473"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4018), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4019), new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "Agric Science", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4019), "Agric Science" },
                    { new Guid("9664541f-5df6-4286-ae23-e94dc656c592"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4013), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4014), new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "Geography", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4013), "Geography" },
                    { new Guid("9a20fe82-fa3f-4f62-829c-428d4a11719f"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3935), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3936), new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "Physics", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3936), "Physics" },
                    { new Guid("b9f1161c-78ca-4716-8cf6-6b331ad8dd4f"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4046), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4047), new Guid("2f76ca48-8044-444b-a965-cd0b5382c911"), "IRS", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4046), "IRS" },
                    { new Guid("d299438c-23c0-4adb-b434-02d1ecd56cda"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4050), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4051), new Guid("2f76ca48-8044-444b-a965-cd0b5382c911"), "Literature-in-English", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4050), "Literature-in-English" },
                    { new Guid("e09637a2-c434-4a29-a554-7c3fa6886b0f"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3955), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3956), new Guid("bb09afb3-8e27-4cae-bd5c-930969c4cc03"), "Further Mathematics", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3955), "Further Mathematics" },
                    { new Guid("eb48627f-7252-437a-a04b-ca493c50b24d"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4038), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4039), new Guid("2f76ca48-8044-444b-a965-cd0b5382c911"), "History", false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(4038), "History" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("1ad22dac-6c70-47d8-9035-03ee4f57e93d"), 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3848), null, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3849), false, 0, new DateTime(2023, 10, 21, 13, 15, 0, 527, DateTimeKind.Local).AddTicks(3848), new Guid("257a82c2-b0d5-467b-b93b-334ad386be2c"), new Guid("2012a23d-d828-43c2-a92f-296ebfa6afe6") });
        }
    }
}
