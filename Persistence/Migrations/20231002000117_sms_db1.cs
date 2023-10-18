using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class sms_db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Departments_DepartmentId",
                table: "Subjects");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("2e9c9c7e-07ce-4c9d-b58f-4caa77709f96"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6274), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6275), "SSS2", false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6274), "SSS2" },
                    { new Guid("37792406-6815-4fc5-b5b7-4a7a29a06b31"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6198), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6199), "SSS1", false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6198), "SSS1" },
                    { new Guid("e3f4691e-a40a-4060-a707-b8acb42dcd9d"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6277), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6277), "SSS3", false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6277), "SSS3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("1b793899-3f44-4572-91d8-f80a86c67d2f"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6029), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6032), "Omo ishe", false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6031), "Teacher" },
                    { new Guid("75f45b3f-5f47-4acd-adae-b04a2660255d"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(5001), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(5001), "Oga pata pata", false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(5001), "Admin" },
                    { new Guid("c61ae655-2d1f-4b31-a248-90a6303376d2"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6037), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6037), "Student", false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6037), "Student" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("82112cda-d506-4178-9e1e-bf67d847d08d"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(4951), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(4965), "Oga@Admin", "Oga@Admin", false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(4964), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("8e208b46-4f0b-4508-93e4-243a9ba3e4dc"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6109), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6109), false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6109), new Guid("82112cda-d506-4178-9e1e-bf67d847d08d") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("d0ade0f5-8125-4543-876d-31ce9725b1b9"), 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6123), null, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6124), false, 0, new DateTime(2023, 10, 2, 1, 1, 17, 344, DateTimeKind.Local).AddTicks(6123), new Guid("75f45b3f-5f47-4acd-adae-b04a2660255d"), new Guid("82112cda-d506-4178-9e1e-bf67d847d08d") });

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Departments_DepartmentId",
                table: "Subjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Departments_DepartmentId",
                table: "Subjects");

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("2e9c9c7e-07ce-4c9d-b58f-4caa77709f96"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("37792406-6815-4fc5-b5b7-4a7a29a06b31"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e3f4691e-a40a-4060-a707-b8acb42dcd9d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b793899-3f44-4572-91d8-f80a86c67d2f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c61ae655-2d1f-4b31-a248-90a6303376d2"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("8e208b46-4f0b-4508-93e4-243a9ba3e4dc"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0ade0f5-8125-4543-876d-31ce9725b1b9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75f45b3f-5f47-4acd-adae-b04a2660255d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("82112cda-d506-4178-9e1e-bf67d847d08d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Departments_DepartmentId",
                table: "Subjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
