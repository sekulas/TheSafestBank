using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafestBankServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataEncryption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "BankClients",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "BankClients",
                columns: new[] { "Id", "AccountNumber", "AddressId", "Balance", "ClientNumber", "Email", "IdentityCardId", "IsBlocked", "LastPasswordResetRequestTime", "LoginAttempts", "Name", "PESEL", "PasswordResetAttempts", "PasswordResetTokenHash", "Salt", "Surname" },
                values: new object[,]
                {
                    { new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), "22345678901234567890123456", new Guid("3e9ac3ba-1a83-4c7b-af99-4d2097f819f9"), 1000.0m, "2", "bob@gmail.com", new Guid("5bfe5536-9bad-4c17-a93f-41ed5634b686"), false, null, 0, "Bob", "22345678901", 0, null, new byte[] { 12, 237, 54, 244, 244, 65, 0, 214, 26, 173, 189, 152, 179, 205, 79, 141 }, "Bobowski" },
                    { new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), "12345678901234567890123456", new Guid("b7cb35f1-4935-4d26-9b4b-7a04a5040b94"), 1000.0m, "1", "sekula.sebastian.kontakt@gmail.com", new Guid("19a8ebad-8068-4790-8b32-1926376f501d"), false, null, 0, "Sebastian", "K853Z4w7o69/6Y73mnpfCQ==", 0, null, new byte[] { 186, 108, 23, 186, 88, 155, 103, 98, 220, 198, 191, 19, 11, 175, 238, 18 }, "Sekula" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "BankClientId", "City", "Country", "HouseNumber", "Street", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("3e9ac3ba-1a83-4c7b-af99-4d2097f819f9"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), "Warszawa", "Poland", "39", "Grójecka", "12-102" },
                    { new Guid("b7cb35f1-4935-4d26-9b4b-7a04a5040b94"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), "jT3F5GEixsCpu20+i9gmzQ==", "Poland", "ZwrSx4pJXIcl2qanqDP5GQ==", "85W+NikqhjYbbhnbCTBFew==", "6ZrKRqcYV/8Sx5K5fwCFuQ==" }
                });

            migrationBuilder.InsertData(
                table: "IdentityCards",
                columns: new[] { "Id", "BankClientId", "CountryOfIssue", "Number", "Serie", "Type" },
                values: new object[,]
                {
                    { new Guid("19a8ebad-8068-4790-8b32-1926376f501d"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), "Poland", "JZV3RjPobB0ufVDUeB3xyg==", "aE0FnNYsy44lu5gQj7hNuQ==", "S1LOmNkwvEOuMB0G09ITag==" },
                    { new Guid("5bfe5536-9bad-4c17-a93f-41ed5634b686"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), "Polska", "22121212", "RXA", "DOWÓD POLSKI" }
                });

            migrationBuilder.InsertData(
                table: "PartialPasswords",
                columns: new[] { "Id", "BankClientId", "Mask", "PartialPasswordHash", "PasswordStatus", "Salt" },
                values: new object[,]
                {
                    { new Guid("1a9bf9a2-257e-44d8-babd-9d5824fdfcd1"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 2, 8, 9 }, new byte[] { 238, 28, 232, 224 }, 1, new byte[] { 13, 110, 219, 177 } },
                    { new Guid("2667f306-dac3-4662-a744-192d42b39226"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 3, 5, 8 }, new byte[] { 66, 29, 59, 77 }, 1, new byte[] { 130, 33, 216, 183 } },
                    { new Guid("36739fe0-b94b-4344-bdec-3c7f9d594ea6"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 0, 1, 3 }, new byte[] { 113, 238, 254, 171 }, 1, new byte[] { 81, 237, 246, 40 } },
                    { new Guid("40dd2f4c-3603-4a12-b6d9-fcd20cdf50db"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 2, 4, 8 }, new byte[] { 143, 58, 171, 39 }, 1, new byte[] { 15, 184, 138, 175 } },
                    { new Guid("40ddf589-0d93-42f8-9d92-66c24598d2a8"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 1, 6, 8 }, new byte[] { 238, 246, 182, 164 }, 1, new byte[] { 222, 98, 70, 59 } },
                    { new Guid("5896248f-375c-4e81-a22a-5c49a82b13a7"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 0, 4, 8 }, new byte[] { 246, 124, 41, 24 }, 1, new byte[] { 182, 177, 252, 177 } },
                    { new Guid("5e51a4ba-6ee4-494f-a901-e8b1e0d20a9f"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 3, 6, 10 }, new byte[] { 166, 22, 63, 80 }, 1, new byte[] { 247, 242, 206, 146 } },
                    { new Guid("613621a7-5acb-468c-a185-252e91e8e8b2"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 1, 4, 8 }, new byte[] { 192, 51, 142, 179 }, 1, new byte[] { 205, 243, 244, 151 } },
                    { new Guid("617a4ae0-202a-4079-b863-200e98b028bb"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 0, 1, 4 }, new byte[] { 95, 206, 178, 92 }, 1, new byte[] { 156, 99, 54, 183 } },
                    { new Guid("72176824-25ea-43bd-b50a-7b16224d2803"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 0, 8, 10 }, new byte[] { 69, 63, 167, 181 }, 1, new byte[] { 69, 207, 33, 121 } },
                    { new Guid("76b53e3d-99e9-42a5-81e6-4d6a240fc2b3"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 1, 6, 7 }, new byte[] { 13, 122, 142, 164 }, 1, new byte[] { 212, 31, 55, 41 } },
                    { new Guid("9a21263e-7630-4878-9c1b-fe3dd6626a85"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 0, 4, 6 }, new byte[] { 104, 137, 76, 235 }, 1, new byte[] { 197, 20, 169, 250 } },
                    { new Guid("9e7dc4f7-52e5-470c-a3ca-932b529cbc44"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 2, 3, 5 }, new byte[] { 117, 2, 52, 40 }, 1, new byte[] { 122, 130, 199, 149 } },
                    { new Guid("a294efb0-c3df-4db1-a312-73a59627f921"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 2, 6, 7 }, new byte[] { 110, 63, 184, 242 }, 2, new byte[] { 189, 8, 252, 80 } },
                    { new Guid("a6e4b9bd-7e69-4342-a056-4b84630eb73e"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 7, 9, 10 }, new byte[] { 172, 50, 12, 230 }, 1, new byte[] { 179, 45, 9, 191 } },
                    { new Guid("c1f863fb-8d4a-4188-b074-121138a327db"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 5, 9, 10 }, new byte[] { 113, 89, 218, 255 }, 1, new byte[] { 140, 192, 189, 16 } },
                    { new Guid("c24a04d3-4f78-430f-a7ea-d15c8055d053"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 2, 5, 9 }, new byte[] { 111, 116, 97, 32 }, 1, new byte[] { 80, 138, 35, 13 } },
                    { new Guid("dc1133d1-c67d-43df-86a5-63205d9252ef"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 1, 6, 9 }, new byte[] { 143, 153, 164, 135 }, 2, new byte[] { 113, 19, 59, 45 } },
                    { new Guid("e327aedf-f6b1-478e-a7b2-25a373795137"), new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"), new[] { 2, 8, 10 }, new byte[] { 155, 186, 124, 189 }, 1, new byte[] { 178, 35, 154, 176 } },
                    { new Guid("fbe0ebb1-c178-4c23-8ec0-0d6880474160"), new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"), new[] { 1, 3, 10 }, new byte[] { 188, 135, 137, 202 }, 1, new byte[] { 110, 240, 51, 182 } }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3e9ac3ba-1a83-4c7b-af99-4d2097f819f9"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b7cb35f1-4935-4d26-9b4b-7a04a5040b94"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("19a8ebad-8068-4790-8b32-1926376f501d"));

            migrationBuilder.DeleteData(
                table: "IdentityCards",
                keyColumn: "Id",
                keyValue: new Guid("5bfe5536-9bad-4c17-a93f-41ed5634b686"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("1a9bf9a2-257e-44d8-babd-9d5824fdfcd1"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("2667f306-dac3-4662-a744-192d42b39226"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("36739fe0-b94b-4344-bdec-3c7f9d594ea6"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("40dd2f4c-3603-4a12-b6d9-fcd20cdf50db"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("40ddf589-0d93-42f8-9d92-66c24598d2a8"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("5896248f-375c-4e81-a22a-5c49a82b13a7"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("5e51a4ba-6ee4-494f-a901-e8b1e0d20a9f"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("613621a7-5acb-468c-a185-252e91e8e8b2"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("617a4ae0-202a-4079-b863-200e98b028bb"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("72176824-25ea-43bd-b50a-7b16224d2803"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("76b53e3d-99e9-42a5-81e6-4d6a240fc2b3"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("9a21263e-7630-4878-9c1b-fe3dd6626a85"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("9e7dc4f7-52e5-470c-a3ca-932b529cbc44"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("a294efb0-c3df-4db1-a312-73a59627f921"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("a6e4b9bd-7e69-4342-a056-4b84630eb73e"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("c1f863fb-8d4a-4188-b074-121138a327db"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("c24a04d3-4f78-430f-a7ea-d15c8055d053"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("dc1133d1-c67d-43df-86a5-63205d9252ef"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("e327aedf-f6b1-478e-a7b2-25a373795137"));

            migrationBuilder.DeleteData(
                table: "PartialPasswords",
                keyColumn: "Id",
                keyValue: new Guid("fbe0ebb1-c178-4c23-8ec0-0d6880474160"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("42a3c4ae-74c3-4137-8d04-fc8f214d7b30"));

            migrationBuilder.DeleteData(
                table: "BankClients",
                keyColumn: "Id",
                keyValue: new Guid("b123b1f6-69a5-49ff-8e3d-8ed04496f2a6"));

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "BankClients");

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
    }
}
