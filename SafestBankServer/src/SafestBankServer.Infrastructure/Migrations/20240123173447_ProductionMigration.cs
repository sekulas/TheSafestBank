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
                    { new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), "22345678901234567890123456", new Guid("a2c9fb28-562c-42c7-851b-60e638a6adf8"), 1000.0m, "223456789012", "bob.bobkins@gmail.com", new Guid("c424201b-3df6-4e3d-aa35-d244dedd47da"), false, null, 0, "Bob", "9Idi5/KqVaNkqHqZH3R4HA==", 0, null, new byte[] { 34, 18, 71, 233, 189, 2, 233, 4, 140, 193, 226, 90, 35, 175, 118, 230 }, "Bobkins" },
                    { new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), "32345678901234567890123456", new Guid("4717c16f-7cb8-4dda-ba6e-109d403087bb"), 1000.0m, "323456789012", "scotty123@gmail.com", new Guid("2bded43b-d53c-42fd-b425-57e746dec85c"), false, null, 0, "Scott", "oiyRFHB+LcV52o4DGcBZTA==", 0, null, new byte[] { 138, 3, 177, 147, 173, 192, 136, 84, 245, 95, 126, 4, 255, 139, 161, 52 }, "Scottkins" },
                    { new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), "12345678901234567890123456", new Guid("32ba2f74-d94f-4057-9f59-00695817c0df"), 1000.0m, "123456789012", "sekula.sebastian.kontakt@gmail.com", new Guid("c87c6e1f-abd6-4c3c-9a5b-20a2e6f9b5c5"), false, null, 0, "Sebastian", "J4PiiRf7uI9DujNSUzN1MA==", 0, null, new byte[] { 179, 54, 227, 57, 244, 98, 97, 0, 202, 201, 72, 162, 127, 143, 213, 134 }, "Sekula" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("32ba2f74-d94f-4057-9f59-00695817c0df"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), "kcrv6nTPjbpz7eWFDfRujg==", "Poland", "O0HgYCAq0H1+ZpmsiNG9bg==", "PcsLAIgh/z5BP9JAb8I8Iw==", "LJNNTRvAN/nkr32ig0eA3A==" },
                    { new Guid("4717c16f-7cb8-4dda-ba6e-109d403087bb"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), "mJ5sYmRqoeMbJu9LpEsVvA==", "Poland", "/g/bQOajO8SBrXeRBPFa5g==", "ICGuFKbIpa1ddyKrrWumqw==", "cCJ6O70OvyIOkAwx8hiK7g==" },
                    { new Guid("a2c9fb28-562c-42c7-851b-60e638a6adf8"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), "mOvPrseSYjD1A0u8yObUDQ==", "Poland", "8JbUpT4Gs1cX5NqRjT+7gQ==", "+fvxX45GKJX1KMO8gpiKXA==", "i4glfOOTvzjR+RKx289LgQ==" }
                });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[,]
                {
                    { new Guid("2bded43b-d53c-42fd-b425-57e746dec85c"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), "Poland", "46h0vavSCFWzUOkSFQ+vqA==", "ZnE+YgAJMaVAaiNgxgfsfA==", "WCDm3fU3Wuz2tP8BtT4Na7w3/u+CrORprbtI0FGD/u4=" },
                    { new Guid("c424201b-3df6-4e3d-aa35-d244dedd47da"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), "Poland", "V0GlMbyAFo3zliyMYk2ktQ==", "Tsb0Tw3EbCUHc/2t5SkCTA==", "L+E9akui4WtydSFLZXVU/KtJgSfDPRVQN7SOnbNhj1s=" },
                    { new Guid("c87c6e1f-abd6-4c3c-9a5b-20a2e6f9b5c5"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), "Poland", "oLskBuEOtZdRkRnXBYKIPQ==", "Ks0V+1ikP9I3B3H+Z8AeVg==", "2i+vNNRDJijpUhTRHB23goxr1IsTzRG5qc4jHyY3PKY=" }
                });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("0cc20c4f-2f10-413b-8fb3-4581b6600237"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 1, 3, 4, 12, 15 }, new byte[] { 58, 222, 74, 125, 9, 101, 171, 192, 179, 100, 226, 47, 239, 103, 98, 129, 250, 116, 114, 206, 248, 230, 108, 32, 127, 189, 139, 112, 168, 166, 247, 37 }, 1, new byte[] { 26, 48, 11, 238, 243, 53, 81, 88, 96, 186, 54, 42, 130, 228, 164, 115 } },
                    { new Guid("1863f786-4eed-4cda-8883-4c984eb7addd"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 1, 4, 11, 12, 14 }, new byte[] { 134, 32, 223, 200, 28, 89, 14, 80, 250, 140, 231, 37, 131, 64, 68, 0, 144, 215, 161, 249, 33, 102, 149, 205, 68, 79, 37, 132, 121, 15, 74, 238 }, 1, new byte[] { 18, 200, 91, 74, 104, 50, 146, 195, 254, 81, 247, 236, 44, 122, 233, 235 } },
                    { new Guid("19b572b7-66de-4510-a08c-2e7c9371711d"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 1, 6, 7, 8, 15 }, new byte[] { 205, 166, 203, 144, 23, 158, 72, 220, 220, 221, 138, 171, 52, 121, 212, 44, 188, 54, 124, 168, 63, 120, 81, 145, 232, 67, 141, 208, 138, 72, 169, 49 }, 1, new byte[] { 173, 245, 60, 41, 227, 111, 211, 243, 104, 113, 7, 191, 135, 29, 0, 76 } },
                    { new Guid("1b1f4cb0-1a57-4bb0-988a-38252e14a35b"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 1, 3, 11, 13, 14 }, new byte[] { 68, 140, 118, 134, 174, 194, 169, 190, 227, 173, 134, 255, 83, 178, 169, 82, 219, 179, 80, 123, 187, 229, 95, 254, 227, 136, 73, 90, 78, 118, 220, 136 }, 1, new byte[] { 3, 183, 52, 95, 104, 104, 73, 103, 39, 168, 59, 115, 145, 26, 95, 36 } },
                    { new Guid("1e13ac7d-44b9-4663-8d23-9e52b0123b08"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 3, 5, 6, 8, 9 }, new byte[] { 70, 4, 169, 26, 225, 203, 131, 71, 121, 223, 3, 15, 75, 75, 163, 52, 5, 63, 134, 123, 34, 95, 161, 174, 190, 23, 57, 40, 30, 240, 152, 91 }, 1, new byte[] { 71, 26, 7, 61, 21, 243, 166, 240, 73, 198, 253, 255, 181, 49, 189, 220 } },
                    { new Guid("276dc943-40a8-4432-bdfe-50415bdbee58"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 0, 1, 2, 3, 7 }, new byte[] { 17, 208, 197, 249, 233, 82, 225, 226, 80, 170, 127, 110, 73, 33, 104, 179, 83, 109, 11, 33, 113, 199, 122, 14, 99, 64, 231, 144, 104, 58, 198, 106 }, 1, new byte[] { 179, 6, 85, 212, 192, 221, 68, 223, 41, 93, 235, 138, 117, 77, 20, 252 } },
                    { new Guid("2eb378f2-8f75-4d9d-8c7c-31e332f05a27"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 5, 6, 7, 8, 9 }, new byte[] { 65, 183, 203, 78, 174, 154, 22, 21, 138, 194, 57, 35, 18, 148, 118, 245, 195, 14, 165, 160, 16, 31, 35, 87, 193, 130, 20, 221, 234, 107, 240, 11 }, 1, new byte[] { 126, 203, 77, 108, 135, 224, 170, 109, 229, 41, 17, 89, 55, 152, 101, 77 } },
                    { new Guid("316d56e8-ddfa-4681-beda-8e0f6fe2223f"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 1, 2, 11, 13, 15 }, new byte[] { 20, 221, 197, 80, 109, 238, 127, 13, 182, 147, 202, 127, 118, 238, 98, 215, 215, 60, 58, 127, 145, 239, 111, 153, 94, 206, 149, 43, 65, 88, 228, 30 }, 2, new byte[] { 64, 166, 160, 213, 46, 246, 167, 242, 160, 7, 231, 77, 133, 118, 106, 26 } },
                    { new Guid("39c5065e-3ef2-4c44-848d-c8a59dbd7164"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 1, 5, 8, 10, 11 }, new byte[] { 113, 201, 85, 224, 109, 57, 21, 122, 70, 253, 13, 87, 75, 46, 76, 158, 29, 250, 106, 196, 247, 125, 9, 60, 101, 102, 115, 215, 95, 234, 226, 184 }, 1, new byte[] { 0, 49, 246, 241, 242, 111, 66, 105, 76, 79, 180, 168, 182, 17, 153, 155 } },
                    { new Guid("3c59de97-6345-4b8d-b150-6b9640282ba7"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 5, 6, 7, 13, 15 }, new byte[] { 147, 251, 57, 255, 63, 45, 185, 103, 155, 185, 129, 240, 129, 232, 36, 88, 53, 31, 125, 179, 130, 222, 176, 66, 144, 65, 110, 254, 233, 196, 133, 43 }, 1, new byte[] { 155, 181, 81, 250, 159, 160, 78, 161, 109, 110, 50, 68, 139, 254, 184, 52 } },
                    { new Guid("4415c6ab-c261-4b1f-af3f-8c825170fae0"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 0, 2, 5, 10, 13 }, new byte[] { 95, 20, 65, 138, 79, 222, 201, 248, 0, 50, 169, 99, 99, 240, 91, 157, 15, 252, 1, 233, 173, 76, 134, 36, 190, 155, 25, 29, 183, 71, 10, 245 }, 1, new byte[] { 209, 127, 231, 185, 190, 163, 210, 108, 156, 101, 38, 238, 165, 169, 49, 246 } },
                    { new Guid("5a51c5f0-59b0-490b-bd16-7b1142366564"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 0, 7, 10, 12, 15 }, new byte[] { 87, 54, 214, 203, 242, 40, 67, 228, 29, 205, 213, 107, 65, 90, 27, 47, 196, 208, 184, 163, 28, 50, 28, 23, 236, 16, 163, 33, 124, 172, 128, 48 }, 1, new byte[] { 220, 0, 129, 245, 86, 221, 40, 29, 3, 162, 33, 164, 5, 239, 69, 113 } },
                    { new Guid("639021ad-2f3d-44ed-bc96-058a844a6b40"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 0, 4, 9, 10, 11 }, new byte[] { 77, 173, 74, 189, 233, 229, 110, 46, 67, 19, 24, 141, 151, 131, 152, 104, 203, 180, 83, 233, 227, 244, 183, 189, 120, 31, 244, 231, 46, 140, 235, 102 }, 1, new byte[] { 72, 203, 94, 196, 105, 56, 209, 19, 219, 38, 12, 19, 178, 60, 1, 61 } },
                    { new Guid("8a5dba35-4375-499e-be3e-0eee958864c6"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 1, 2, 5, 10, 13 }, new byte[] { 65, 28, 11, 156, 247, 20, 2, 77, 203, 35, 27, 182, 88, 136, 49, 231, 120, 24, 205, 127, 18, 61, 212, 215, 171, 152, 252, 30, 121, 151, 96, 65 }, 2, new byte[] { 43, 41, 103, 4, 56, 100, 211, 40, 0, 238, 171, 200, 233, 34, 172, 252 } },
                    { new Guid("94f7308c-d770-4349-b249-dfc111d2b072"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 2, 4, 6, 7, 12 }, new byte[] { 150, 174, 233, 66, 56, 97, 38, 193, 250, 213, 192, 76, 69, 155, 218, 213, 92, 156, 17, 77, 252, 22, 238, 133, 180, 121, 144, 100, 129, 219, 193, 162 }, 1, new byte[] { 6, 202, 158, 51, 107, 170, 24, 197, 145, 171, 34, 204, 5, 18, 204, 50 } },
                    { new Guid("a862a697-2195-4fa1-9930-01524abd558c"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 7, 8, 11, 12, 15 }, new byte[] { 13, 29, 229, 234, 170, 137, 74, 22, 199, 34, 76, 207, 49, 214, 79, 197, 253, 64, 221, 165, 128, 188, 2, 47, 9, 227, 252, 47, 129, 109, 216, 243 }, 1, new byte[] { 190, 69, 235, 164, 222, 251, 46, 149, 28, 43, 177, 77, 101, 208, 62, 80 } },
                    { new Guid("aa1b7aa0-291c-4f53-a4ac-2302834f77f0"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 2, 7, 10, 14, 15 }, new byte[] { 144, 4, 219, 240, 116, 17, 57, 162, 234, 192, 33, 49, 124, 133, 79, 14, 47, 148, 72, 110, 122, 69, 82, 42, 87, 214, 241, 218, 161, 16, 105, 75 }, 1, new byte[] { 104, 148, 77, 100, 21, 254, 168, 220, 193, 150, 242, 21, 252, 47, 21, 76 } },
                    { new Guid("aa23d1ac-f36e-4db1-84f7-1b617894e1c5"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 1, 7, 9, 10, 11 }, new byte[] { 203, 78, 128, 204, 94, 231, 135, 122, 101, 100, 125, 216, 239, 238, 128, 53, 184, 73, 186, 116, 220, 123, 110, 140, 175, 66, 154, 96, 213, 229, 18, 26 }, 1, new byte[] { 241, 60, 188, 222, 127, 150, 41, 173, 7, 251, 162, 123, 109, 164, 200, 95 } },
                    { new Guid("b1001258-dac9-4749-9f0d-089aaf5b7701"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 4, 6, 10, 13, 15 }, new byte[] { 242, 107, 75, 60, 20, 76, 125, 118, 205, 229, 106, 84, 108, 56, 139, 88, 193, 177, 246, 55, 220, 215, 88, 228, 172, 6, 215, 154, 231, 12, 225, 231 }, 1, new byte[] { 60, 74, 159, 160, 219, 184, 105, 235, 89, 191, 231, 159, 60, 59, 165, 72 } },
                    { new Guid("b4a55758-6e9d-4cc9-a6dc-35a4794280fa"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 0, 2, 3, 8, 12 }, new byte[] { 184, 28, 225, 137, 77, 78, 147, 2, 52, 51, 3, 165, 115, 114, 49, 173, 251, 243, 150, 239, 110, 14, 58, 127, 18, 105, 62, 52, 253, 255, 205, 217 }, 1, new byte[] { 180, 133, 135, 131, 11, 84, 213, 36, 71, 39, 25, 42, 42, 216, 0, 102 } },
                    { new Guid("bbffdadc-3d65-4552-91f8-9f5bfb1eb5fd"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 3, 4, 7, 11, 12 }, new byte[] { 80, 244, 56, 62, 164, 57, 26, 13, 73, 191, 176, 202, 119, 66, 98, 220, 133, 74, 31, 214, 102, 67, 168, 91, 11, 252, 31, 50, 248, 131, 41, 76 }, 1, new byte[] { 50, 98, 13, 213, 129, 183, 152, 7, 184, 14, 5, 50, 205, 222, 246, 54 } },
                    { new Guid("c4f6a99d-6dfa-4b65-88be-8c33a9755f9a"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 9, 10, 12, 13, 14 }, new byte[] { 30, 210, 151, 30, 213, 134, 32, 200, 214, 190, 239, 181, 106, 141, 112, 57, 242, 201, 193, 139, 171, 240, 85, 178, 217, 135, 246, 74, 71, 54, 35, 15 }, 1, new byte[] { 220, 253, 12, 137, 110, 119, 146, 110, 101, 89, 175, 122, 105, 2, 15, 182 } },
                    { new Guid("c943c6ae-6cd0-4636-a7f1-ea8b96df2f15"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 1, 4, 5, 11, 12 }, new byte[] { 18, 120, 154, 128, 9, 52, 205, 18, 227, 79, 24, 215, 58, 26, 15, 238, 136, 211, 64, 12, 119, 198, 14, 108, 215, 228, 96, 210, 8, 58, 30, 252 }, 1, new byte[] { 86, 36, 110, 115, 42, 244, 79, 235, 232, 78, 44, 190, 52, 105, 221, 186 } },
                    { new Guid("e008fcb0-ac3e-41bc-b486-72c706266a3a"), new Guid("46d2048f-7de1-47f1-9163-e1b084b65cde"), new[] { 0, 2, 3, 11, 14 }, new byte[] { 126, 203, 126, 7, 157, 89, 83, 166, 55, 235, 34, 221, 232, 168, 48, 142, 37, 35, 100, 12, 130, 250, 157, 70, 55, 254, 22, 110, 90, 169, 115, 120 }, 1, new byte[] { 20, 167, 10, 230, 86, 51, 185, 112, 76, 24, 50, 85, 207, 153, 212, 251 } },
                    { new Guid("e3e76270-7b6d-4e52-ba32-31c08353beaa"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 1, 5, 6, 9, 15 }, new byte[] { 128, 146, 158, 109, 174, 160, 160, 246, 84, 82, 6, 38, 37, 234, 111, 208, 91, 52, 44, 35, 207, 12, 88, 181, 19, 83, 188, 45, 191, 20, 133, 203 }, 1, new byte[] { 180, 58, 79, 27, 185, 232, 190, 151, 152, 246, 195, 134, 22, 163, 246, 76 } },
                    { new Guid("f67b4056-3e3c-40ab-9255-004487e3edba"), new Guid("1e1dab8d-9625-4262-8f46-bc43ac58b2c0"), new[] { 0, 1, 3, 11, 13 }, new byte[] { 110, 144, 67, 134, 176, 120, 251, 45, 166, 79, 189, 48, 62, 85, 8, 194, 49, 171, 115, 33, 14, 198, 214, 211, 187, 47, 72, 136, 28, 110, 122, 198 }, 1, new byte[] { 165, 177, 9, 84, 95, 61, 239, 214, 29, 76, 239, 140, 5, 222, 210, 113 } },
                    { new Guid("fd1e9a78-2c7c-430d-b4ba-a5bffee2bca1"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 0, 1, 9, 12, 15 }, new byte[] { 3, 96, 151, 219, 242, 212, 64, 152, 210, 50, 246, 25, 183, 48, 210, 156, 167, 78, 58, 51, 175, 186, 13, 209, 9, 6, 104, 128, 141, 219, 0, 114 }, 1, new byte[] { 184, 52, 125, 74, 38, 249, 22, 213, 124, 102, 67, 111, 80, 77, 105, 23 } },
                    { new Guid("fea2c52c-5c7f-49c3-8bbf-abe124eacd3a"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 1, 4, 5, 10, 14 }, new byte[] { 235, 32, 163, 108, 18, 10, 43, 159, 61, 17, 93, 134, 131, 178, 3, 0, 96, 224, 204, 110, 73, 226, 114, 23, 95, 220, 22, 230, 55, 102, 25, 11 }, 1, new byte[] { 210, 107, 221, 156, 228, 65, 72, 60, 252, 144, 93, 64, 79, 252, 127, 254 } },
                    { new Guid("fec714ba-feb5-4876-a50b-d6a89dda6ec8"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 0, 2, 6, 7, 11 }, new byte[] { 103, 102, 189, 81, 72, 174, 147, 5, 150, 21, 151, 1, 210, 121, 130, 45, 201, 18, 245, 255, 205, 223, 93, 55, 160, 175, 172, 199, 247, 154, 191, 151 }, 2, new byte[] { 183, 129, 122, 28, 31, 247, 205, 255, 59, 40, 66, 229, 186, 17, 79, 159 } },
                    { new Guid("ffdddb0d-4438-4b10-bc40-3b84f452c45c"), new Guid("0dadb77d-9c27-4bd8-b1e3-c642b159f02d"), new[] { 1, 3, 4, 5, 6 }, new byte[] { 54, 223, 53, 141, 12, 138, 31, 124, 23, 30, 73, 208, 138, 12, 254, 63, 173, 190, 229, 37, 202, 41, 75, 163, 252, 164, 17, 214, 2, 213, 70, 52 }, 1, new byte[] { 166, 250, 217, 249, 12, 130, 205, 83, 210, 186, 56, 239, 183, 74, 225, 143 } }
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
