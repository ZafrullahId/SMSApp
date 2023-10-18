using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Payment_StudentId",
                table: "Payment",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

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
        }
    }
}
