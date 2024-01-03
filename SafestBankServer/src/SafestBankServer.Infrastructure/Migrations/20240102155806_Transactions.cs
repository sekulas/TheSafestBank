using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafestBankServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Transactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2a94861f-0741-4605-ad2d-23f1ea906249"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("52f2eb1b-42e9-41fe-be4d-30082e93183a"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("05b6b5e3-f5bd-4925-be93-e083f4671f95"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("0954f5b9-c421-45f8-abe3-b20a2c6447b5"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("34c3f096-df37-44c1-997c-1f3047b4d3e3"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("3675d236-4f70-40b6-ac84-33d9be97e3c4"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("3752e41d-d60c-43aa-97b9-0289e889ee0c"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("694dc4bb-081e-4e23-aefb-22fb2dbc42ff"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("9c034f8a-07aa-46c4-87f4-9e270b252c0c"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("aa696330-1a9a-43cd-a879-c680b3d8e5c8"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("c788f1da-e244-4552-aef4-782c17107888"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("f09369fd-c8c9-49f7-acf7-eaceda3e974e"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"));

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "BankClients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "BankClients",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ClientTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    BankClientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientTransaction_BankClients_BankClientId",
                        column: x => x.BankClientId,
                        principalTable: "BankClients",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransaction_BankClientId",
                table: "ClientTransaction",
                column: "BankClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTransaction");

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
                name: "AccountNumber",
                table: "BankClients");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "BankClients");

            migrationBuilder.InsertData(
                table: "BankClients",
                columns: new[] { "Id", "AddressId", "ClientNumber", "Email", "IdentityCardId", "Name", "PESEL", "Surname" },
                values: new object[] { new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new Guid("2a94861f-0741-4605-ad2d-23f1ea906249"), "1", "sekula.sebastian.kontakt@gmail.com", new Guid("52f2eb1b-42e9-41fe-be4d-30082e93183a"), "Sebastian", "12345678901", "Sekula" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[] { new Guid("2a94861f-0741-4605-ad2d-23f1ea906249"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), "Warszawa", "Poland", "39", "Grójecka", "12-102" });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[] { new Guid("52f2eb1b-42e9-41fe-be4d-30082e93183a"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), "Polska", "12121212", "RXA", "DOWÓD POLSKI" });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("05b6b5e3-f5bd-4925-be93-e083f4671f95"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 0, 2, 8 }, new byte[] { 6, 15, 230, 89 }, 1, new byte[] { 217, 191, 48, 22 } },
                    { new Guid("0954f5b9-c421-45f8-abe3-b20a2c6447b5"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 0, 4, 7 }, new byte[] { 238, 210, 76, 79 }, 1, new byte[] { 85, 151, 91, 200 } },
                    { new Guid("34c3f096-df37-44c1-997c-1f3047b4d3e3"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 3, 8, 9 }, new byte[] { 37, 54, 5, 24 }, 1, new byte[] { 140, 202, 54, 242 } },
                    { new Guid("3675d236-4f70-40b6-ac84-33d9be97e3c4"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 2, 8, 10 }, new byte[] { 208, 37, 192, 131 }, 1, new byte[] { 232, 141, 118, 205 } },
                    { new Guid("3752e41d-d60c-43aa-97b9-0289e889ee0c"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 3, 4, 5 }, new byte[] { 92, 98, 246, 2 }, 2, new byte[] { 232, 195, 73, 40 } },
                    { new Guid("694dc4bb-081e-4e23-aefb-22fb2dbc42ff"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 1, 8, 9 }, new byte[] { 166, 149, 68, 78 }, 1, new byte[] { 205, 58, 16, 171 } },
                    { new Guid("9c034f8a-07aa-46c4-87f4-9e270b252c0c"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 0, 6, 10 }, new byte[] { 161, 221, 142, 29 }, 1, new byte[] { 69, 254, 17, 19 } },
                    { new Guid("aa696330-1a9a-43cd-a879-c680b3d8e5c8"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 7, 9, 10 }, new byte[] { 238, 62, 122, 198 }, 1, new byte[] { 145, 248, 135, 246 } },
                    { new Guid("c788f1da-e244-4552-aef4-782c17107888"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 0, 9, 10 }, new byte[] { 18, 241, 136, 249 }, 1, new byte[] { 140, 191, 234, 199 } },
                    { new Guid("f09369fd-c8c9-49f7-acf7-eaceda3e974e"), new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"), new[] { 3, 5, 9 }, new byte[] { 138, 20, 177, 110 }, 1, new byte[] { 132, 4, 221, 157 } }
                });
        }
    }
}
