using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafestBankServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PasswordReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("314fbce9-222d-43ea-9db1-16907d943388"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("35b93122-98a1-4acf-963d-d370dc4bde4d"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("2d7b08ce-9254-49d7-9301-4cdcfa1d1e3b"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("4a8c677f-8cc0-4384-aa3a-d45b1c063e7a"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("36db3fad-3882-4b69-acb0-e31048732dd4"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("46fef6d7-5e79-4776-b57d-2e6eb1eebc7d"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("52ac063f-c6b1-4609-9270-2e6f0005ea06"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("5801788c-0123-4bc9-a0b8-efdbad56a3f9"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("64f91cb2-0fab-4e75-a577-87786ea93a58"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("836f884a-c012-4356-9111-f4c9e347da9d"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("95579ecb-11be-48a0-9f78-f1d479913220"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("96e5a982-1c49-4a99-856a-02bdd4d920f8"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("98c92922-fa57-4328-9f4d-6cf7e3977f41"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("99bea296-a6c4-4df7-81f5-4c4c96f695cd"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("9dd855bb-af01-42db-9e08-1958499bb767"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("b3a60b18-3930-482b-8316-bb0529eade2e"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("c591385b-171a-4981-8de5-c48fb21822e7"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("ccb214f1-901f-4ff8-adb0-3fa7eb0d0231"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("d0343e0d-a240-4120-be8b-a0dc0c3ebdae"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("d69c3192-31ac-4f84-a05d-24c42ca51ab4"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("db858bdb-3389-4ecc-aaae-907ebfcc1563"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("e96cc834-60d3-4f83-8bf1-aae85299b320"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("ef206ac8-7752-4e02-a86f-31c74588de95"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("f4433381-3291-4e2b-b0e0-d81e8152fab4"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPasswordResetRequestTime",
                table: "BankClients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PasswordResetAttempts",
                table: "BankClients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordResetTokenHash",
                table: "BankClients",
                type: "bytea",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BankClients",
                columns: new[] { "Id", "AccountNumber", "AddressId", "Balance", "ClientNumber", "Email", "IdentityCardId", "IsBlocked", "LastPasswordResetRequestTime", "LoginAttempts", "Name", "PESEL", "PasswordResetAttempts", "PasswordResetTokenHash", "Surname" },
                values: new object[,]
                {
                    { new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), "12345678901234567890123456", new Guid("ef1b20c9-8707-4c3c-b81e-a189991839c3"), 1000.0m, "1", "sekula.sebastian.kontakt@gmail.com", new Guid("88706890-918e-4a44-bf8f-e3e13a0baa9e"), false, null, 0, "Sebastian", "12345678901", 0, null, "Sekula" },
                    { new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), "22345678901234567890123456", new Guid("9c2389a5-0311-4358-9c0e-35e6139d1fff"), 1000.0m, "2", "bob@gmail.com", new Guid("49062219-64f7-4512-971d-36f3371d6a41"), false, null, 0, "Bob", "22345678901", 0, null, "Bobowski" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("9c2389a5-0311-4358-9c0e-35e6139d1fff"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), "Warszawa", "Poland", "39", "Grójecka", "12-102" },
                    { new Guid("ef1b20c9-8707-4c3c-b81e-a189991839c3"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), "Warszawa", "Poland", "39", "Grójecka", "12-102" }
                });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[,]
                {
                    { new Guid("49062219-64f7-4512-971d-36f3371d6a41"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), "Polska", "22121212", "RXA", "DOWÓD POLSKI" },
                    { new Guid("88706890-918e-4a44-bf8f-e3e13a0baa9e"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), "Polska", "12121212", "RXA", "DOWÓD POLSKI" }
                });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("1c0fdc5f-4d83-47fc-a77c-b088703236e3"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 5, 6, 7 }, new byte[] { 138, 211, 92, 189 }, 1, new byte[] { 19, 177, 188, 4 } },
                    { new Guid("23bafdc0-cb2c-4204-ad68-de1c140df5ed"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 3, 5, 7 }, new byte[] { 253, 254, 131, 242 }, 1, new byte[] { 125, 93, 80, 128 } },
                    { new Guid("2637cf5b-f60b-49e7-ad20-7c9fab8cbabe"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 1, 2, 10 }, new byte[] { 62, 127, 32, 166 }, 1, new byte[] { 255, 253, 20, 93 } },
                    { new Guid("3795727f-5deb-41c2-bf68-3d11ef81d61d"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 2, 6, 7 }, new byte[] { 156, 150, 214, 156 }, 1, new byte[] { 45, 186, 175, 107 } },
                    { new Guid("418858d9-fcbb-4b80-b8d3-e5d55e4faed9"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 1, 9, 10 }, new byte[] { 72, 235, 152, 97 }, 1, new byte[] { 203, 172, 161, 82 } },
                    { new Guid("4e933509-5e15-4393-ae6c-d81d662c2234"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 2, 5, 7 }, new byte[] { 162, 201, 205, 248 }, 1, new byte[] { 126, 88, 123, 50 } },
                    { new Guid("504fbfb6-169b-44fd-b62c-8d127d52b110"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 2, 8, 10 }, new byte[] { 121, 97, 231, 92 }, 1, new byte[] { 191, 8, 107, 47 } },
                    { new Guid("76815ccd-1932-4e69-8474-40fc6856a7d7"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 2, 5, 9 }, new byte[] { 31, 135, 183, 240 }, 1, new byte[] { 244, 75, 255, 49 } },
                    { new Guid("8f4ee295-42db-4c94-b372-b05daf940c71"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 0, 1, 10 }, new byte[] { 81, 152, 122, 116 }, 1, new byte[] { 19, 156, 86, 160 } },
                    { new Guid("9c8b927b-a021-44b6-ba21-a12e3e2bea54"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 2, 3, 9 }, new byte[] { 199, 220, 254, 7 }, 2, new byte[] { 148, 65, 115, 140 } },
                    { new Guid("9d10c826-c3e5-46a2-a28c-ded705bd3bc2"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 0, 2, 5 }, new byte[] { 110, 215, 98, 10 }, 1, new byte[] { 4, 111, 11, 128 } },
                    { new Guid("b187374b-6418-467b-a126-849151854652"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 0, 2, 9 }, new byte[] { 100, 31, 91, 51 }, 1, new byte[] { 88, 58, 111, 101 } },
                    { new Guid("b98b0682-ecf4-4bb6-9443-d04097f7dc38"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 3, 5, 8 }, new byte[] { 133, 50, 49, 96 }, 1, new byte[] { 224, 130, 83, 225 } },
                    { new Guid("bd99cc93-3e15-4914-9e72-e85ec5dad981"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 6, 8, 9 }, new byte[] { 202, 189, 178, 195 }, 1, new byte[] { 172, 240, 112, 242 } },
                    { new Guid("ca9013e9-a807-4634-a5a5-8373ae1df0cb"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 1, 4, 6 }, new byte[] { 127, 164, 71, 66 }, 1, new byte[] { 35, 218, 45, 86 } },
                    { new Guid("dc760491-4d45-4574-8006-da0e45953c1c"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 1, 4, 8 }, new byte[] { 89, 226, 165, 79 }, 1, new byte[] { 236, 82, 36, 140 } },
                    { new Guid("dd372714-3ce9-4e02-aa1d-0cfafc347baf"), new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"), new[] { 2, 5, 10 }, new byte[] { 128, 177, 37, 211 }, 1, new byte[] { 244, 21, 180, 11 } },
                    { new Guid("e9c788f4-ea48-4e22-8366-a1e869eb2d2c"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 1, 4, 5 }, new byte[] { 155, 33, 64, 112 }, 1, new byte[] { 179, 82, 28, 99 } },
                    { new Guid("f59118a8-335d-423c-bc06-72f6fd8afcf0"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 3, 4, 9 }, new byte[] { 113, 134, 205, 121 }, 2, new byte[] { 26, 152, 245, 255 } },
                    { new Guid("f76fe2ac-c117-405c-9e75-125d50442975"), new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"), new[] { 3, 6, 8 }, new byte[] { 180, 104, 168, 241 }, 1, new byte[] { 117, 46, 225, 38 } }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("9c2389a5-0311-4358-9c0e-35e6139d1fff"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("ef1b20c9-8707-4c3c-b81e-a189991839c3"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("49062219-64f7-4512-971d-36f3371d6a41"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("88706890-918e-4a44-bf8f-e3e13a0baa9e"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("1c0fdc5f-4d83-47fc-a77c-b088703236e3"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("23bafdc0-cb2c-4204-ad68-de1c140df5ed"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("2637cf5b-f60b-49e7-ad20-7c9fab8cbabe"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("3795727f-5deb-41c2-bf68-3d11ef81d61d"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("418858d9-fcbb-4b80-b8d3-e5d55e4faed9"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("4e933509-5e15-4393-ae6c-d81d662c2234"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("504fbfb6-169b-44fd-b62c-8d127d52b110"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("76815ccd-1932-4e69-8474-40fc6856a7d7"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("8f4ee295-42db-4c94-b372-b05daf940c71"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("9c8b927b-a021-44b6-ba21-a12e3e2bea54"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("9d10c826-c3e5-46a2-a28c-ded705bd3bc2"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("b187374b-6418-467b-a126-849151854652"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("b98b0682-ecf4-4bb6-9443-d04097f7dc38"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("bd99cc93-3e15-4914-9e72-e85ec5dad981"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("ca9013e9-a807-4634-a5a5-8373ae1df0cb"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("dc760491-4d45-4574-8006-da0e45953c1c"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("dd372714-3ce9-4e02-aa1d-0cfafc347baf"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("e9c788f4-ea48-4e22-8366-a1e869eb2d2c"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("f59118a8-335d-423c-bc06-72f6fd8afcf0"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("f76fe2ac-c117-405c-9e75-125d50442975"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("1d9dc8be-afc3-42b1-988f-344b1d4c80cc"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("ce00448a-7717-4cdd-9d38-75c7e7d9a677"));

            migrationBuilder.DropColumn(
                name: "LastPasswordResetRequestTime",
                table: "BankClients");

            migrationBuilder.DropColumn(
                name: "PasswordResetAttempts",
                table: "BankClients");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenHash",
                table: "BankClients");

            migrationBuilder.InsertData(
                table: "BankClients",
                columns: new[] { "Id", "AccountNumber", "AddressId", "Balance", "ClientNumber", "Email", "IdentityCardId", "IsBlocked", "LoginAttempts", "Name", "PESEL", "Surname" },
                values: new object[,]
                {
                    { new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), "22345678901234567890123456", new Guid("314fbce9-222d-43ea-9db1-16907d943388"), 1000.0m, "2", "bob@gmail.com", new Guid("2d7b08ce-9254-49d7-9301-4cdcfa1d1e3b"), false, 0, "Bob", "22345678901", "Bobowski" },
                    { new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), "12345678901234567890123456", new Guid("35b93122-98a1-4acf-963d-d370dc4bde4d"), 1000.0m, "1", "sekula.sebastian.kontakt@gmail.com", new Guid("4a8c677f-8cc0-4384-aa3a-d45b1c063e7a"), false, 0, "Sebastian", "12345678901", "Sekula" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("314fbce9-222d-43ea-9db1-16907d943388"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), "Warszawa", "Poland", "39", "Grójecka", "12-102" },
                    { new Guid("35b93122-98a1-4acf-963d-d370dc4bde4d"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), "Warszawa", "Poland", "39", "Grójecka", "12-102" }
                });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[,]
                {
                    { new Guid("2d7b08ce-9254-49d7-9301-4cdcfa1d1e3b"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), "Polska", "22121212", "RXA", "DOWÓD POLSKI" },
                    { new Guid("4a8c677f-8cc0-4384-aa3a-d45b1c063e7a"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), "Polska", "12121212", "RXA", "DOWÓD POLSKI" }
                });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("36db3fad-3882-4b69-acb0-e31048732dd4"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 0, 5, 8 }, new byte[] { 21, 205, 69, 95 }, 1, new byte[] { 162, 88, 156, 247 } },
                    { new Guid("46fef6d7-5e79-4776-b57d-2e6eb1eebc7d"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 4, 7, 10 }, new byte[] { 206, 220, 102, 222 }, 1, new byte[] { 1, 245, 227, 51 } },
                    { new Guid("52ac063f-c6b1-4609-9270-2e6f0005ea06"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 0, 4, 9 }, new byte[] { 225, 42, 235, 156 }, 1, new byte[] { 86, 52, 103, 198 } },
                    { new Guid("5801788c-0123-4bc9-a0b8-efdbad56a3f9"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 1, 5, 6 }, new byte[] { 136, 9, 175, 176 }, 1, new byte[] { 203, 238, 60, 215 } },
                    { new Guid("64f91cb2-0fab-4e75-a577-87786ea93a58"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 1, 7, 8 }, new byte[] { 254, 45, 10, 99 }, 1, new byte[] { 230, 70, 187, 150 } },
                    { new Guid("836f884a-c012-4356-9111-f4c9e347da9d"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 0, 5, 6 }, new byte[] { 96, 150, 215, 51 }, 1, new byte[] { 132, 84, 112, 140 } },
                    { new Guid("95579ecb-11be-48a0-9f78-f1d479913220"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 4, 9, 10 }, new byte[] { 163, 146, 34, 144 }, 1, new byte[] { 36, 60, 103, 13 } },
                    { new Guid("96e5a982-1c49-4a99-856a-02bdd4d920f8"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 5, 8, 10 }, new byte[] { 174, 82, 68, 17 }, 2, new byte[] { 229, 45, 165, 78 } },
                    { new Guid("98c92922-fa57-4328-9f4d-6cf7e3977f41"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 2, 5, 9 }, new byte[] { 241, 182, 27, 66 }, 1, new byte[] { 248, 118, 10, 250 } },
                    { new Guid("99bea296-a6c4-4df7-81f5-4c4c96f695cd"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 5, 7, 10 }, new byte[] { 1, 52, 49, 62 }, 1, new byte[] { 186, 104, 10, 218 } },
                    { new Guid("9dd855bb-af01-42db-9e08-1958499bb767"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 1, 5, 10 }, new byte[] { 247, 129, 49, 108 }, 1, new byte[] { 117, 203, 35, 24 } },
                    { new Guid("b3a60b18-3930-482b-8316-bb0529eade2e"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 1, 5, 8 }, new byte[] { 69, 164, 20, 51 }, 1, new byte[] { 202, 123, 241, 95 } },
                    { new Guid("c591385b-171a-4981-8de5-c48fb21822e7"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 2, 9, 10 }, new byte[] { 74, 38, 187, 214 }, 1, new byte[] { 222, 24, 163, 41 } },
                    { new Guid("ccb214f1-901f-4ff8-adb0-3fa7eb0d0231"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 1, 2, 8 }, new byte[] { 184, 33, 55, 53 }, 2, new byte[] { 60, 165, 183, 22 } },
                    { new Guid("d0343e0d-a240-4120-be8b-a0dc0c3ebdae"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 3, 7, 8 }, new byte[] { 20, 254, 194, 156 }, 1, new byte[] { 134, 0, 175, 46 } },
                    { new Guid("d69c3192-31ac-4f84-a05d-24c42ca51ab4"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 3, 9, 10 }, new byte[] { 140, 219, 144, 197 }, 1, new byte[] { 18, 107, 199, 131 } },
                    { new Guid("db858bdb-3389-4ecc-aaae-907ebfcc1563"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 0, 2, 7 }, new byte[] { 210, 251, 62, 90 }, 1, new byte[] { 151, 186, 153, 195 } },
                    { new Guid("e96cc834-60d3-4f83-8bf1-aae85299b320"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 5, 6, 9 }, new byte[] { 205, 254, 92, 227 }, 1, new byte[] { 63, 75, 49, 112 } },
                    { new Guid("ef206ac8-7752-4e02-a86f-31c74588de95"), new Guid("30011b44-a32a-48fd-967d-f8e9ecf4438f"), new[] { 3, 8, 10 }, new byte[] { 90, 239, 126, 149 }, 1, new byte[] { 146, 176, 13, 163 } },
                    { new Guid("f4433381-3291-4e2b-b0e0-d81e8152fab4"), new Guid("be3d7aca-3504-42e3-a30d-8acd9d0e14ea"), new[] { 0, 3, 6 }, new byte[] { 130, 225, 197, 250 }, 1, new byte[] { 190, 13, 123, 127 } }
                });
        }
    }
}
