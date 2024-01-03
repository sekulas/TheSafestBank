using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafestBankServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TransactionsPart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransaction_BankClients_BankClientId",
                table: "ClientTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientTransaction",
                table: "ClientTransaction");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("616401ac-853f-4981-8c88-3a6476e1af05"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("6b3f302b-ff04-4c63-acc3-62911a3595b3"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("459ef917-bd84-452e-8e26-b69f43e3cdbe"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("fa98850b-1502-4269-b8a1-ec6d3899f313"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("0b0629de-92f1-44a7-9e5a-0ef49ba13500"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("10a82069-be59-4dcd-b46d-d4e9498fe435"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("153a513f-e1fb-4ece-8970-77237a599000"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("1b2b0c0f-8c7b-40e8-b2d1-22947c12a84e"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("21bf0a36-9079-495b-bc85-48a9faa8193f"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("26c6db5e-ea58-4e06-8c78-dfb3f3fe8a1f"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("2be2486d-f795-4239-a614-b36c358b4ed8"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("2eac6f41-b854-43b9-b999-5d3add68143a"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("637c6a10-3b0f-4916-ba20-0b2c9fbf23a3"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("63f49d44-b8fc-4951-9542-714f3db189ed"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("63fc53fd-03c9-41c3-9a4f-e1e18163929b"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("76342a6a-8626-484a-ade1-3dddfe1d2f8b"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("8b509a2d-2caf-40a5-871f-f37f06046963"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("8f00684f-352f-4a65-927a-e027f3425063"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("96abd29a-08c0-46c8-b7fa-0104a02111a6"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("a31ae437-d3d8-4b6e-8506-c04f74f67d92"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("c0da7376-4781-42b6-9c85-d92568489b8a"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("c37821f0-66f1-45a5-812e-18713da4f5a7"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("e49b6c43-f479-4157-95af-01e9f3370ce2"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("ea04a126-8896-455e-ad38-5de192aea2c6"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ClientTransaction");

            migrationBuilder.RenameTable(
                name: "ClientTransaction",
                newName: "ClientTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTransaction_BankClientId",
                table: "ClientTransactions",
                newName: "IX_ClientTransactions_BankClientId");

            migrationBuilder.AddColumn<string>(
                name: "RecipientAccountNumber",
                table: "ClientTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientName",
                table: "ClientTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipientSurname",
                table: "ClientTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderAccountNumber",
                table: "ClientTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "ClientTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderSurname",
                table: "ClientTransactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "ClientTransactions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientTransactions",
                table: "ClientTransactions",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransactions_BankClients_BankClientId",
                table: "ClientTransactions",
                column: "BankClientId",
                principalTable: "BankClients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientTransactions_BankClients_BankClientId",
                table: "ClientTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientTransactions",
                table: "ClientTransactions");

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

            migrationBuilder.DropColumn(
                name: "RecipientAccountNumber",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "RecipientName",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "RecipientSurname",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "SenderAccountNumber",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "SenderSurname",
                table: "ClientTransactions");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ClientTransactions");

            migrationBuilder.RenameTable(
                name: "ClientTransactions",
                newName: "ClientTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_ClientTransactions_BankClientId",
                table: "ClientTransaction",
                newName: "IX_ClientTransaction_BankClientId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "ClientTransaction",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientTransaction",
                table: "ClientTransaction",
                column: "Id");

            migrationBuilder.InsertData(
                table: "BankClients",
                columns: new[] { "Id", "AccountNumber", "AddressId", "Balance", "ClientNumber", "Email", "IdentityCardId", "Name", "PESEL", "Surname" },
                values: new object[,]
                {
                    { new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), "12345678901234567890123456", new Guid("616401ac-853f-4981-8c88-3a6476e1af05"), 1000.0m, "1", "sekula.sebastian.kontakt@gmail.com", new Guid("fa98850b-1502-4269-b8a1-ec6d3899f313"), "Sebastian", "12345678901", "Sekula" },
                    { new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), "22345678901234567890123456", new Guid("6b3f302b-ff04-4c63-acc3-62911a3595b3"), 1000.0m, "2", "bob@gmail.com", new Guid("459ef917-bd84-452e-8e26-b69f43e3cdbe"), "Bob", "22345678901", "Bobowski" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("616401ac-853f-4981-8c88-3a6476e1af05"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), "Warszawa", "Poland", "39", "Grójecka", "12-102" },
                    { new Guid("6b3f302b-ff04-4c63-acc3-62911a3595b3"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), "Warszawa", "Poland", "39", "Grójecka", "12-102" }
                });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[,]
                {
                    { new Guid("459ef917-bd84-452e-8e26-b69f43e3cdbe"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), "Polska", "22121212", "RXA", "DOWÓD POLSKI" },
                    { new Guid("fa98850b-1502-4269-b8a1-ec6d3899f313"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), "Polska", "12121212", "RXA", "DOWÓD POLSKI" }
                });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("0b0629de-92f1-44a7-9e5a-0ef49ba13500"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 2, 5, 10 }, new byte[] { 226, 45, 250, 112 }, 1, new byte[] { 194, 5, 158, 192 } },
                    { new Guid("10a82069-be59-4dcd-b46d-d4e9498fe435"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 7, 8, 9 }, new byte[] { 135, 60, 132, 147 }, 2, new byte[] { 244, 161, 61, 25 } },
                    { new Guid("153a513f-e1fb-4ece-8970-77237a599000"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 2, 4, 10 }, new byte[] { 132, 139, 109, 171 }, 1, new byte[] { 228, 86, 8, 80 } },
                    { new Guid("1b2b0c0f-8c7b-40e8-b2d1-22947c12a84e"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 0, 3, 6 }, new byte[] { 30, 0, 72, 53 }, 1, new byte[] { 145, 98, 72, 132 } },
                    { new Guid("21bf0a36-9079-495b-bc85-48a9faa8193f"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 2, 4, 7 }, new byte[] { 228, 199, 199, 105 }, 2, new byte[] { 222, 184, 217, 249 } },
                    { new Guid("26c6db5e-ea58-4e06-8c78-dfb3f3fe8a1f"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 3, 4, 8 }, new byte[] { 217, 138, 254, 28 }, 1, new byte[] { 147, 47, 3, 238 } },
                    { new Guid("2be2486d-f795-4239-a614-b36c358b4ed8"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 1, 7, 9 }, new byte[] { 159, 14, 244, 241 }, 1, new byte[] { 182, 24, 107, 161 } },
                    { new Guid("2eac6f41-b854-43b9-b999-5d3add68143a"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 3, 5, 10 }, new byte[] { 255, 10, 21, 79 }, 1, new byte[] { 113, 175, 108, 170 } },
                    { new Guid("637c6a10-3b0f-4916-ba20-0b2c9fbf23a3"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 3, 5, 9 }, new byte[] { 89, 21, 155, 151 }, 1, new byte[] { 121, 190, 7, 201 } },
                    { new Guid("63f49d44-b8fc-4951-9542-714f3db189ed"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 1, 5, 9 }, new byte[] { 18, 173, 248, 176 }, 1, new byte[] { 219, 193, 103, 8 } },
                    { new Guid("63fc53fd-03c9-41c3-9a4f-e1e18163929b"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 4, 5, 9 }, new byte[] { 175, 31, 21, 186 }, 1, new byte[] { 63, 113, 27, 208 } },
                    { new Guid("76342a6a-8626-484a-ade1-3dddfe1d2f8b"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 2, 7, 10 }, new byte[] { 187, 207, 56, 52 }, 1, new byte[] { 227, 39, 171, 13 } },
                    { new Guid("8b509a2d-2caf-40a5-871f-f37f06046963"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 2, 7, 9 }, new byte[] { 17, 115, 140, 96 }, 1, new byte[] { 207, 189, 179, 94 } },
                    { new Guid("8f00684f-352f-4a65-927a-e027f3425063"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 3, 4, 10 }, new byte[] { 62, 244, 253, 59 }, 1, new byte[] { 235, 227, 79, 93 } },
                    { new Guid("96abd29a-08c0-46c8-b7fa-0104a02111a6"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 0, 1, 9 }, new byte[] { 200, 183, 85, 199 }, 1, new byte[] { 213, 197, 89, 210 } },
                    { new Guid("a31ae437-d3d8-4b6e-8506-c04f74f67d92"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 1, 3, 4 }, new byte[] { 206, 21, 193, 42 }, 1, new byte[] { 71, 70, 80, 61 } },
                    { new Guid("c0da7376-4781-42b6-9c85-d92568489b8a"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 5, 6, 10 }, new byte[] { 90, 21, 186, 70 }, 1, new byte[] { 171, 209, 101, 61 } },
                    { new Guid("c37821f0-66f1-45a5-812e-18713da4f5a7"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 1, 5, 10 }, new byte[] { 170, 58, 225, 34 }, 1, new byte[] { 4, 57, 126, 234 } },
                    { new Guid("e49b6c43-f479-4157-95af-01e9f3370ce2"), new Guid("a2eb23c2-17b3-4157-bfe3-a667a3e6916d"), new[] { 0, 4, 7 }, new byte[] { 250, 28, 72, 187 }, 1, new byte[] { 95, 19, 203, 99 } },
                    { new Guid("ea04a126-8896-455e-ad38-5de192aea2c6"), new Guid("e2e1327d-f75a-4577-88f9-1f73744f4a85"), new[] { 5, 6, 7 }, new byte[] { 90, 126, 120, 5 }, 1, new byte[] { 21, 242, 41, 12 } }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTransaction_BankClients_BankClientId",
                table: "ClientTransaction",
                column: "BankClientId",
                principalTable: "BankClients",
                principalColumn: "Id");
        }
    }
}
