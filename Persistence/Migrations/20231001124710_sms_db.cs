using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class sms_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("329367e4-2d0e-4cf7-91c7-aef7c2490144"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6b68ffe9-ea3e-417d-9ced-8a318cc43626"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("c7338e9c-005f-4393-8776-a37f8da7eaa0"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("08b39d1d-ba13-4dc8-b94d-18bce8925617"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("61459348-1e6a-4f4a-a8c9-9c0e68350caf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87f889a9-52ae-4e78-9090-ef2d70254f4a"));

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("501da85e-180f-4958-b74c-a4f194064aae"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3074), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3075), "SSS1", false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3074), "SSS1" },
                    { new Guid("7d279483-9090-4c85-b95c-3c86be43329c"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3080), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3081), "SSS3", false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3080), "SSS3" },
                    { new Guid("fc1279b4-2527-40df-8cb7-b2993ea6e35b"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3077), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3078), "SSS2", false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3078), "SSS2" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("55d12fc7-89ee-47c3-95c7-7f789799c922"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2878), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2879), "Student", false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2878), "Student" },
                    { new Guid("8efc44a3-96b3-41ab-83ae-7875c0ebf1bc"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2858), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2860), "Omo ishe", false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2860), "Teacher" },
                    { new Guid("b0e09195-f19d-4384-b0f3-275ada80f76b"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(1790), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(1790), "Oga pata pata", false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(1790), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("a93566ae-407b-4466-b3b7-f21a268b40cc"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(1738), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(1751), "Oga@Admin", "Oga@Admin", false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(1751), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("6160eece-a19e-4c5f-badd-636c101ae281"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2946), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2946), false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(2946), new Guid("a93566ae-407b-4466-b3b7-f21a268b40cc") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("689c6e0a-b383-49f8-81be-79be71235135"), 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3007), null, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3008), false, 0, new DateTime(2023, 10, 1, 13, 47, 9, 683, DateTimeKind.Local).AddTicks(3008), new Guid("b0e09195-f19d-4384-b0f3-275ada80f76b"), new Guid("a93566ae-407b-4466-b3b7-f21a268b40cc") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("501da85e-180f-4958-b74c-a4f194064aae"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("7d279483-9090-4c85-b95c-3c86be43329c"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fc1279b4-2527-40df-8cb7-b2993ea6e35b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("55d12fc7-89ee-47c3-95c7-7f789799c922"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8efc44a3-96b3-41ab-83ae-7875c0ebf1bc"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("6160eece-a19e-4c5f-badd-636c101ae281"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("689c6e0a-b383-49f8-81be-79be71235135"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b0e09195-f19d-4384-b0f3-275ada80f76b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a93566ae-407b-4466-b3b7-f21a268b40cc"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("329367e4-2d0e-4cf7-91c7-aef7c2490144"), 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7286), null, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7288), "Omo ishe", false, 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7288), "Teacher" },
                    { new Guid("61459348-1e6a-4f4a-a8c9-9c0e68350caf"), 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(6011), null, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(6012), "Oga pata pata", false, 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(6012), "Admin" },
                    { new Guid("6b68ffe9-ea3e-417d-9ced-8a318cc43626"), 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7295), null, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7295), "Student", false, 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7295), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("87f889a9-52ae-4e78-9090-ef2d70254f4a"), 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(5965), null, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(5978), "Oga@Admin", "Oga@Admin", false, 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(5977), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("c7338e9c-005f-4393-8776-a37f8da7eaa0"), 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7460), null, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7460), false, 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7460), new Guid("87f889a9-52ae-4e78-9090-ef2d70254f4a") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("08b39d1d-ba13-4dc8-b94d-18bce8925617"), 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7477), null, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7478), false, 0, new DateTime(2023, 10, 1, 13, 29, 32, 880, DateTimeKind.Local).AddTicks(7478), new Guid("61459348-1e6a-4f4a-a8c9-9c0e68350caf"), new Guid("87f889a9-52ae-4e78-9090-ef2d70254f4a") });
        }
    }
}
