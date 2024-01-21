using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafestBankServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientNumber = table.Column<string>(type: "text", nullable: false),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PESEL = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginAttempts = table.Column<int>(type: "integer", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordResetAttempts = table.Column<int>(type: "integer", nullable: false),
                    LastPasswordResetRequestTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PasswordResetTokenHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    IdentityCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    HouseNumber = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    BankClientId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_BankClients_BankClientId",
                        column: x => x.BankClientId,
                        principalTable: "BankClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderName = table.Column<string>(type: "text", nullable: false),
                    SenderSurname = table.Column<string>(type: "text", nullable: false),
                    SenderAccountNumber = table.Column<string>(type: "text", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientName = table.Column<string>(type: "text", nullable: false),
                    RecipientSurname = table.Column<string>(type: "text", nullable: false),
                    RecipientAccountNumber = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    BankClientId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientTransactions_BankClients_BankClientId",
                        column: x => x.BankClientId,
                        principalTable: "BankClients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IdentityCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Serie = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    CountryOfIssue = table.Column<string>(type: "text", nullable: false),
                    BankClientId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityCards_BankClients_BankClientId",
                        column: x => x.BankClientId,
                        principalTable: "BankClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartialPasswords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Mask = table.Column<int[]>(type: "integer[]", nullable: false),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PartialPasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordStatus = table.Column<int>(type: "integer", nullable: false),
                    BankClientId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartialPasswords_BankClients_BankClientId",
                        column: x => x.BankClientId,
                        principalTable: "BankClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankClients",
                columns: new[] { "Id", "AccountNumber", "AddressId", "Balance", "ClientNumber", "Email", "IdentityCardId", "IsBlocked", "LastPasswordResetRequestTime", "LoginAttempts", "Name", "PESEL", "PasswordResetAttempts", "PasswordResetTokenHash", "Salt", "Surname" },
                values: new object[,]
                {
                    { new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), "32345678901234567890123456", new Guid("61bfbb5a-4ee5-444a-9e04-e7aaf4472d5f"), 1000.0m, "323456789012", "scotty123@gmail.com", new Guid("5647486d-1526-4671-8137-6a20c77a814e"), false, null, 0, "Scott", "FfOhfvnCQH3oDkgJM7fM/A==", 0, null, new byte[] { 34, 30, 91, 238, 72, 248, 254, 89, 68, 93, 17, 250, 60, 82, 251, 208 }, "Scottkins" },
                    { new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), "22345678901234567890123456", new Guid("8314e254-d65d-418a-9384-e3f138d2c44c"), 1000.0m, "223456789012", "bob.bobkins@gmail.com", new Guid("599d5e6d-bb55-42b7-9a9a-821f9571184c"), false, null, 0, "Bob", "qyqhwpiQWlgb3K/nbDadCQ==", 0, null, new byte[] { 51, 210, 119, 33, 201, 91, 29, 123, 52, 203, 155, 152, 97, 33, 152, 139 }, "Bobkins" },
                    { new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), "12345678901234567890123456", new Guid("b24cfa60-0786-43f5-b0af-454bb48b9b4f"), 1000.0m, "123456789012", "sekula.sebastian.kontakt@gmail.com", new Guid("0743407a-05c6-462c-bc59-bf4c791d28eb"), false, null, 0, "Sebastian", "kiFZ9Vuou0loCNeWZ1M5Pg==", 0, null, new byte[] { 29, 36, 114, 132, 62, 241, 164, 14, 149, 188, 63, 9, 230, 133, 118, 69 }, "Sekula" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("61bfbb5a-4ee5-444a-9e04-e7aaf4472d5f"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), "B9f+T8voSnGBWqHXo9HLJA==", "Poland", "y+HDXbYIpnMP0A7JZEyOxg==", "qgoIc4Y38u4wskOOZ3QBiA==", "zynqUtQL9YHg4ATA3/F0tQ==" },
                    { new Guid("8314e254-d65d-418a-9384-e3f138d2c44c"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), "Vbn7s5StymHZbBWa9Cgpkg==", "Poland", "atp/SNeKi9yptW1vOQw9eQ==", "jbw6JMH1jZmcbpXyGJoGsA==", "7Tcj33TdENeQc6Wm+bmvBw==" },
                    { new Guid("b24cfa60-0786-43f5-b0af-454bb48b9b4f"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), "4qFIWfcFUIKBRGpy+b2iJg==", "Poland", "ngq0Jt0InNy9g+hITQESCw==", "4IceSwS9SsG10rzss0mAxQ==", "XlieGi2Ixh1BiluN3pE32A==" }
                });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[,]
                {
                    { new Guid("0743407a-05c6-462c-bc59-bf4c791d28eb"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), "Poland", "NnY5mgee5nCi2nlaSR9UbQ==", "gcPmZpxpoQN6CNSiiS99KQ==", "nESIu1Y4omSZIk+/UrjffClK+CSdXSjx7OcIDZwMAyM=" },
                    { new Guid("5647486d-1526-4671-8137-6a20c77a814e"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), "Poland", "gFYhHo6eq3xxJNC64UxD7A==", "jW8pOz5YQunDmkMWdVyZGQ==", "BMtjDY6JrkHdJRjMhVEncyCTgznmG6KwxuOhHuW9sVM=" },
                    { new Guid("599d5e6d-bb55-42b7-9a9a-821f9571184c"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), "Poland", "8jekknPdaXFow7ktFcpviQ==", "vLDAxeWieYMYq6qvfU7Lcg==", "TcoDlo5j9l4A+CZ84/L3QTAMfE0BuPVHd+TUp71OTQc=" }
                });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("04918818-b483-4750-8742-43bb050a74f9"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 2, 7, 9, 10, 14 }, new byte[] { 60, 88, 123, 60 }, 1, new byte[] { 179, 81, 122, 213 } },
                    { new Guid("08c2aade-3a81-49a1-9d8f-123ab2a8564c"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 0, 4, 8, 12, 14 }, new byte[] { 119, 63, 194, 172 }, 1, new byte[] { 20, 74, 170, 63 } },
                    { new Guid("16fa8c47-bb88-4b5c-992b-81167ef5910d"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 0, 1, 2, 4, 8 }, new byte[] { 206, 120, 244, 104 }, 1, new byte[] { 102, 47, 59, 74 } },
                    { new Guid("180bf7bf-b477-439c-917e-80f98f8ccf63"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 0, 4, 5, 10, 15 }, new byte[] { 77, 23, 201, 230 }, 1, new byte[] { 58, 10, 104, 67 } },
                    { new Guid("1888cdc2-8a0b-4b7f-bd3d-f50692076af6"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 1, 4, 6, 9, 15 }, new byte[] { 119, 122, 206, 88 }, 1, new byte[] { 119, 210, 86, 227 } },
                    { new Guid("3dc9ec29-4f75-4ce1-b5d7-00ba2f301c10"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 0, 1, 5, 6, 7 }, new byte[] { 37, 254, 87, 55 }, 1, new byte[] { 235, 184, 220, 180 } },
                    { new Guid("3fe63246-342c-44a3-987e-633575c3acc3"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 2, 4, 6, 9, 14 }, new byte[] { 137, 243, 165, 119 }, 1, new byte[] { 60, 223, 72, 87 } },
                    { new Guid("4adefcd8-92b2-4432-a7ce-7dac026553d0"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 4, 6, 10, 12, 13 }, new byte[] { 221, 51, 74, 80 }, 1, new byte[] { 125, 212, 143, 233 } },
                    { new Guid("6e070a07-6faf-44ed-b4b1-0b827a8963dc"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 9, 10, 12, 14, 15 }, new byte[] { 102, 182, 100, 149 }, 1, new byte[] { 231, 174, 7, 252 } },
                    { new Guid("7d1a55de-dda9-4fd9-8388-ae04bc5dc8ea"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 7, 9, 10, 11, 14 }, new byte[] { 168, 128, 105, 180 }, 1, new byte[] { 144, 148, 244, 116 } },
                    { new Guid("89d9b9b7-d235-4985-b3cf-ed9dd997be00"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 0, 4, 7, 14, 15 }, new byte[] { 48, 88, 140, 186 }, 1, new byte[] { 175, 217, 26, 178 } },
                    { new Guid("8aa11fd3-51a6-49f4-97bf-401cd02bb824"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 7, 9, 12, 14, 15 }, new byte[] { 53, 5, 173, 153 }, 1, new byte[] { 120, 6, 55, 239 } },
                    { new Guid("91216156-3bc8-4849-92e3-63d0cf2db86e"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 5, 6, 8, 12, 14 }, new byte[] { 0, 249, 135, 47 }, 1, new byte[] { 246, 202, 127, 231 } },
                    { new Guid("96d80488-8d84-4f7d-ac0d-4b7a9177001e"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 0, 3, 10, 13, 14 }, new byte[] { 111, 48, 40, 86 }, 1, new byte[] { 37, 185, 0, 222 } },
                    { new Guid("97b89af3-2501-4ef9-9a6b-b511510ddda6"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 2, 3, 6, 9, 10 }, new byte[] { 201, 84, 132, 39 }, 2, new byte[] { 137, 76, 252, 26 } },
                    { new Guid("9a10966c-e728-4171-ad32-f435b12ca91a"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 0, 1, 6, 8, 11 }, new byte[] { 71, 45, 53, 50 }, 1, new byte[] { 0, 105, 93, 31 } },
                    { new Guid("9a240026-5254-40ab-b486-ca744ecf8493"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 5, 6, 10, 11, 15 }, new byte[] { 94, 27, 100, 235 }, 1, new byte[] { 136, 157, 151, 139 } },
                    { new Guid("9d29e5ca-230b-427e-9f0e-4fe2119a549b"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 1, 5, 13, 14, 15 }, new byte[] { 146, 245, 163, 13 }, 1, new byte[] { 158, 247, 58, 15 } },
                    { new Guid("a234a513-9a71-490d-8abe-88da7909a396"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 5, 6, 9, 12, 15 }, new byte[] { 83, 122, 128, 174 }, 1, new byte[] { 255, 90, 36, 59 } },
                    { new Guid("aa10adf5-1335-44bf-955b-e2a83ff93c9a"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 1, 4, 9, 11, 15 }, new byte[] { 54, 180, 59, 61 }, 1, new byte[] { 255, 198, 4, 8 } },
                    { new Guid("c2142a5d-1238-449c-94a4-bbdfa20ee4b8"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 0, 2, 6, 10, 11 }, new byte[] { 77, 17, 59, 163 }, 1, new byte[] { 188, 23, 21, 99 } },
                    { new Guid("ce058595-2184-466f-93d2-ecd6a60499ff"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 0, 2, 3, 14, 15 }, new byte[] { 111, 233, 146, 141 }, 1, new byte[] { 65, 143, 165, 34 } },
                    { new Guid("d4413960-699c-405e-98d2-b6d63ae3794e"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 4, 6, 7, 8, 12 }, new byte[] { 130, 102, 248, 69 }, 2, new byte[] { 92, 96, 54, 81 } },
                    { new Guid("dc4d15f1-5550-4683-a6f4-f7a54992c121"), new Guid("b216e9bd-4cc3-429b-b1cb-f11f673faa0d"), new[] { 9, 11, 12, 13, 15 }, new byte[] { 29, 59, 100, 63 }, 1, new byte[] { 164, 132, 206, 65 } },
                    { new Guid("dfe9818b-fb71-44e6-b5c5-60355c76542b"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 2, 6, 12, 14, 15 }, new byte[] { 193, 123, 54, 89 }, 1, new byte[] { 218, 81, 68, 104 } },
                    { new Guid("e0552eb4-2b5b-4e25-beff-46550cfb0e8f"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 1, 7, 9, 10, 13 }, new byte[] { 140, 249, 93, 214 }, 2, new byte[] { 34, 7, 1, 196 } },
                    { new Guid("e2635041-7598-4ca2-a072-2a8c4f460f10"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 1, 2, 8, 10, 12 }, new byte[] { 150, 45, 106, 63 }, 1, new byte[] { 182, 194, 163, 105 } },
                    { new Guid("ef27f363-bdb5-46e1-ac31-48b8cef320ae"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 3, 6, 8, 11, 15 }, new byte[] { 65, 90, 3, 89 }, 1, new byte[] { 178, 97, 247, 164 } },
                    { new Guid("ef48b8ce-1693-4f99-8152-b75f72ec6f2c"), new Guid("b4092f92-57fd-4032-b73d-e407036d3abf"), new[] { 3, 5, 10, 12, 15 }, new byte[] { 201, 60, 26, 226 }, 1, new byte[] { 151, 110, 54, 237 } },
                    { new Guid("fa57b2a3-1454-49cf-83e6-8654da665767"), new Guid("03a8dd46-180f-415e-80d0-3c7a5e9b3750"), new[] { 0, 3, 4, 10, 15 }, new byte[] { 177, 100, 199, 111 }, 1, new byte[] { 18, 178, 232, 88 } }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BankClientId",
                table: "Addresses",
                column: "BankClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_BankClientId",
                table: "ClientTransactions",
                column: "BankClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityCards_BankClientId",
                table: "IdentityCards",
                column: "BankClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartialPasswords_BankClientId",
                table: "PartialPasswords",
                column: "BankClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ClientTransactions");

            migrationBuilder.DropTable(
                name: "IdentityCards");

            migrationBuilder.DropTable(
                name: "PartialPasswords");

            migrationBuilder.DropTable(
                name: "BankClients");
        }
    }
}
