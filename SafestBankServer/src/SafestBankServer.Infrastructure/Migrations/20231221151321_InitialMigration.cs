using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafestBankServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    PESEL = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentityCardId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BankClientId",
                table: "Addresses",
                column: "BankClientId",
                unique: true);

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
                name: "IdentityCards");

            migrationBuilder.DropTable(
                name: "PartialPasswords");

            migrationBuilder.DropTable(
                name: "BankClients");
        }
    }
}
