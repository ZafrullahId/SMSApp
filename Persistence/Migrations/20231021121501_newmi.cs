using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class newmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
