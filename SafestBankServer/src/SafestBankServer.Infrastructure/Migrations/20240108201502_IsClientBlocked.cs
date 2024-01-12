using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafestBankServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsClientBlocked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("26dcc92f-f0b3-4e5f-868d-ac968fd98548"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("36905ecd-7515-46e3-b28d-2d6ede1b51b6"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("46b7afe8-29f1-4d30-949e-a674131bf1ce"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("90d5f5b2-4f6d-4d75-b609-de55d3a41c7e"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("07b7067a-49c0-4cbd-bf95-18384e09d5b5"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("15a5e670-4f6c-4174-abaf-b395b744d233"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("29c74bc3-5965-446c-9925-8810eeb7ff79"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("2cc4f663-51c6-4fc3-83eb-007f08a2b2e6"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("354659d8-f210-44ee-b375-b975e8978496"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("406d649f-2319-4986-852a-1cc5715ce06d"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("5317307f-f31a-4ea1-9a6e-9b847f8eb19f"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("54680887-a3b1-46ee-a3aa-dd0e2e6fd6fe"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("79ad984e-f4f3-45d9-acd7-d2ea5af6cf22"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("8f7404b6-ecbe-44dd-9dcb-9a3880905d2d"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("a6217b73-0a2a-4ffa-953b-86999129e7ba"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("b3362ca4-274c-465b-bc96-1ec8ec38d4c8"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("b835fb63-04a1-496f-84e3-7ca15823e38c"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("d059924c-b531-4d1a-b82d-904ac97e01ea"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("d17d746f-b5dd-431d-87b4-9359a090064c"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("d8af05aa-f489-4cdf-bdb5-1f7904d11733"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("e7d119e2-8f73-4475-be0d-043b85be977c"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("e7d281c3-ea9a-46bf-8373-273702a504ba"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("f6adb44a-d4af-488a-a112-6ca3e70ba642"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("f6fa1e15-8ca5-48c8-9e36-b3cbdd12ee45"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("59126f13-5104-4814-a296-8534024c624e"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"));

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "BankClients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LoginAttempts",
                table: "BankClients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "BankClients");

            migrationBuilder.DropColumn(
                name: "LoginAttempts",
                table: "BankClients");

            migrationBuilder.InsertData(
                table: "BankClients",
                columns: new[] { "Id", "AccountNumber", "AddressId", "Balance", "ClientNumber", "Email", "IdentityCardId", "Name", "PESEL", "Surname" },
                values: new object[,]
                {
                    { new Guid("59126f13-5104-4814-a296-8534024c624e"), "22345678901234567890123456", new Guid("26dcc92f-f0b3-4e5f-868d-ac968fd98548"), 1000.0m, "2", "bob@gmail.com", new Guid("46b7afe8-29f1-4d30-949e-a674131bf1ce"), "Bob", "22345678901", "Bobowski" },
                    { new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), "12345678901234567890123456", new Guid("36905ecd-7515-46e3-b28d-2d6ede1b51b6"), 1000.0m, "1", "sekula.sebastian.kontakt@gmail.com", new Guid("90d5f5b2-4f6d-4d75-b609-de55d3a41c7e"), "Sebastian", "12345678901", "Sekula" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("26dcc92f-f0b3-4e5f-868d-ac968fd98548"), new Guid("59126f13-5104-4814-a296-8534024c624e"), "Warszawa", "Poland", "39", "Grójecka", "12-102" },
                    { new Guid("36905ecd-7515-46e3-b28d-2d6ede1b51b6"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), "Warszawa", "Poland", "39", "Grójecka", "12-102" }
                });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[,]
                {
                    { new Guid("46b7afe8-29f1-4d30-949e-a674131bf1ce"), new Guid("59126f13-5104-4814-a296-8534024c624e"), "Polska", "22121212", "RXA", "DOWÓD POLSKI" },
                    { new Guid("90d5f5b2-4f6d-4d75-b609-de55d3a41c7e"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), "Polska", "12121212", "RXA", "DOWÓD POLSKI" }
                });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("07b7067a-49c0-4cbd-bf95-18384e09d5b5"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 0, 2, 4 }, new byte[] { 213, 94, 241, 66 }, 1, new byte[] { 154, 188, 76, 27 } },
                    { new Guid("15a5e670-4f6c-4174-abaf-b395b744d233"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 2, 5, 9 }, new byte[] { 65, 109, 53, 84 }, 1, new byte[] { 2, 32, 33, 104 } },
                    { new Guid("29c74bc3-5965-446c-9925-8810eeb7ff79"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 1, 5, 6 }, new byte[] { 22, 18, 145, 128 }, 1, new byte[] { 37, 173, 223, 142 } },
                    { new Guid("2cc4f663-51c6-4fc3-83eb-007f08a2b2e6"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 3, 8, 9 }, new byte[] { 138, 23, 174, 134 }, 1, new byte[] { 84, 79, 48, 92 } },
                    { new Guid("354659d8-f210-44ee-b375-b975e8978496"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 0, 1, 10 }, new byte[] { 140, 38, 228, 83 }, 1, new byte[] { 119, 53, 182, 221 } },
                    { new Guid("406d649f-2319-4986-852a-1cc5715ce06d"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 4, 5, 6 }, new byte[] { 209, 55, 167, 10 }, 1, new byte[] { 149, 71, 80, 171 } },
                    { new Guid("5317307f-f31a-4ea1-9a6e-9b847f8eb19f"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 1, 2, 7 }, new byte[] { 232, 32, 78, 37 }, 1, new byte[] { 133, 101, 195, 121 } },
                    { new Guid("54680887-a3b1-46ee-a3aa-dd0e2e6fd6fe"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 2, 6, 9 }, new byte[] { 226, 41, 101, 169 }, 1, new byte[] { 196, 109, 140, 9 } },
                    { new Guid("79ad984e-f4f3-45d9-acd7-d2ea5af6cf22"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 4, 6, 10 }, new byte[] { 112, 185, 247, 67 }, 2, new byte[] { 169, 181, 1, 21 } },
                    { new Guid("8f7404b6-ecbe-44dd-9dcb-9a3880905d2d"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 3, 6, 8 }, new byte[] { 91, 77, 74, 230 }, 1, new byte[] { 237, 75, 161, 154 } },
                    { new Guid("a6217b73-0a2a-4ffa-953b-86999129e7ba"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 4, 5, 7 }, new byte[] { 93, 107, 43, 21 }, 1, new byte[] { 58, 7, 131, 129 } },
                    { new Guid("b3362ca4-274c-465b-bc96-1ec8ec38d4c8"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 5, 7, 8 }, new byte[] { 175, 31, 198, 148 }, 1, new byte[] { 74, 166, 78, 195 } },
                    { new Guid("b835fb63-04a1-496f-84e3-7ca15823e38c"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 5, 9, 10 }, new byte[] { 108, 77, 191, 18 }, 1, new byte[] { 76, 15, 79, 100 } },
                    { new Guid("d059924c-b531-4d1a-b82d-904ac97e01ea"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 1, 2, 4 }, new byte[] { 123, 247, 10, 99 }, 1, new byte[] { 231, 0, 41, 68 } },
                    { new Guid("d17d746f-b5dd-431d-87b4-9359a090064c"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 0, 8, 9 }, new byte[] { 202, 51, 108, 194 }, 1, new byte[] { 20, 31, 66, 210 } },
                    { new Guid("d8af05aa-f489-4cdf-bdb5-1f7904d11733"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 2, 4, 7 }, new byte[] { 48, 72, 108, 53 }, 1, new byte[] { 61, 141, 216, 50 } },
                    { new Guid("e7d119e2-8f73-4475-be0d-043b85be977c"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 1, 2, 5 }, new byte[] { 95, 245, 60, 229 }, 1, new byte[] { 72, 197, 6, 37 } },
                    { new Guid("e7d281c3-ea9a-46bf-8373-273702a504ba"), new Guid("789b48f2-b9d4-4bf0-990e-ca32b54fdbc2"), new[] { 2, 5, 8 }, new byte[] { 176, 192, 9, 19 }, 1, new byte[] { 233, 184, 68, 92 } },
                    { new Guid("f6adb44a-d4af-488a-a112-6ca3e70ba642"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 0, 3, 7 }, new byte[] { 14, 249, 168, 204 }, 2, new byte[] { 79, 54, 134, 219 } },
                    { new Guid("f6fa1e15-8ca5-48c8-9e36-b3cbdd12ee45"), new Guid("59126f13-5104-4814-a296-8534024c624e"), new[] { 4, 5, 9 }, new byte[] { 25, 88, 126, 86 }, 1, new byte[] { 11, 209, 81, 255 } }
                });
        }
    }
}
