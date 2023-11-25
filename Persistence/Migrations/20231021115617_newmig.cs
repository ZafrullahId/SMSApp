using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class newmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("75b82238-b5ef-4383-a8d7-2cc5eb2446b6"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("cbd5d7c5-77cf-42a6-87d3-e87f2dc203fa"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f81f5ecc-4726-46e8-854d-ce849ec5f23d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2cbd36bf-8684-4ec9-b323-5aa45cad0ad8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8605eb7c-a016-4a26-aa0f-58ce3158b86d"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("b3b34575-d83f-45e7-87d0-728dbd5d47a1"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3cc3925-5f6f-4840-bd34-ac3391397683"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a9a5b71f-6e79-4341-86b5-f39b8a781eb6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb6fc4d1-6c00-45d8-856d-28ee10cfef93"));

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("2b0e3c35-59c5-4707-8e3a-28bbb9738595"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2868), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2869), "SSS3", false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2869), "SSS3" },
                    { new Guid("b9b6010e-2724-4262-a3c6-bb10346a712e"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2800), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2801), "SSS1", false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2800), "SSS1" },
                    { new Guid("da48579b-7be2-4fec-80e8-a9423c83a406"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2818), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2820), "SSS2", false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2819), "SSS2" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("30e290d8-394f-46db-8e1b-28601e4404ce"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2597), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2598), "Student", false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2598), "Student" },
                    { new Guid("9eb31e09-2d22-4f8a-bcd1-60acb165aaa2"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(1007), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(1008), "Oga pata pata", false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(1007), "Admin" },
                    { new Guid("fac0b71e-fee0-4653-afbe-140346cae58a"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2584), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2587), "Omo ishe", false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2586), "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("71eb9eee-f36e-455d-a284-ef2925204468"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(946), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(965), "Oga@Admin", "Oga@Admin", false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(965), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("c4609d07-7cab-4bf9-b852-2679af0fbc68"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2749), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2750), false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2750), new Guid("71eb9eee-f36e-455d-a284-ef2925204468") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("dd459ae1-54d6-4151-885c-5e36f01817e9"), 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2774), null, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2775), false, 0, new DateTime(2023, 10, 21, 12, 56, 16, 915, DateTimeKind.Local).AddTicks(2774), new Guid("9eb31e09-2d22-4f8a-bcd1-60acb165aaa2"), new Guid("71eb9eee-f36e-455d-a284-ef2925204468") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("2b0e3c35-59c5-4707-8e3a-28bbb9738595"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("b9b6010e-2724-4262-a3c6-bb10346a712e"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("da48579b-7be2-4fec-80e8-a9423c83a406"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("30e290d8-394f-46db-8e1b-28601e4404ce"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fac0b71e-fee0-4653-afbe-140346cae58a"));

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: new Guid("c4609d07-7cab-4bf9-b852-2679af0fbc68"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd459ae1-54d6-4151-885c-5e36f01817e9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9eb31e09-2d22-4f8a-bcd1-60acb165aaa2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("71eb9eee-f36e-455d-a284-ef2925204468"));

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("75b82238-b5ef-4383-a8d7-2cc5eb2446b6"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5434), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5435), "SSS3", false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5434), "SSS3" },
                    { new Guid("cbd5d7c5-77cf-42a6-87d3-e87f2dc203fa"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5427), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5428), "SSS1", false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5428), "SSS1" },
                    { new Guid("f81f5ecc-4726-46e8-854d-ce849ec5f23d"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5431), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5431), "SSS2", false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5431), "SSS2" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("2cbd36bf-8684-4ec9-b323-5aa45cad0ad8"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5299), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5301), "Omo ishe", false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5301), "Teacher" },
                    { new Guid("8605eb7c-a016-4a26-aa0f-58ce3158b86d"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5308), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5308), "Student", false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5308), "Student" },
                    { new Guid("a9a5b71f-6e79-4341-86b5-f39b8a781eb6"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(4338), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(4339), "Oga pata pata", false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(4339), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "FullName", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Password", "PhoneNumber", "ProfileImage" },
                values: new object[] { new Guid("cb6fc4d1-6c00-45d8-856d-28ee10cfef93"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(4293), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(4304), "Oga@Admin", "Oga@Admin", false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(4304), "password", "1234567890", null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "UserId" },
                values: new object[] { new Guid("b3b34575-d83f-45e7-87d0-728dbd5d47a1"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5385), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5385), false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5385), new Guid("cb6fc4d1-6c00-45d8-856d-28ee10cfef93") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "RoleId", "UserId" },
                values: new object[] { new Guid("e3cc3925-5f6f-4840-bd34-ac3391397683"), 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5410), null, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5410), false, 0, new DateTime(2023, 10, 18, 15, 43, 50, 30, DateTimeKind.Local).AddTicks(5410), new Guid("a9a5b71f-6e79-4341-86b5-f39b8a781eb6"), new Guid("cb6fc4d1-6c00-45d8-856d-28ee10cfef93") });
        }
    }
}
