﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SafestBankServer.Infrastructure.EF.Contexts;

#nullable disable

namespace SafestBankServer.Infrastructure.Migrations
{
    [DbContext(typeof(SafestBankDbContext))]
    [Migration("20231221151321_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SafestBankServer.Core.Auth.Passwords.PartialPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BankClientId")
                        .HasColumnType("uuid");

                    b.Property<int[]>("Mask")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<byte[]>("PartialPasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("PasswordStatus")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("BankClientId");

                    b.ToTable("PartialPasswords");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3752e41d-d60c-43aa-97b9-0289e889ee0c"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 3, 4, 5 },
                            PartialPasswordHash = new byte[] { 92, 98, 246, 2 },
                            PasswordStatus = 2,
                            Salt = new byte[] { 232, 195, 73, 40 }
                        },
                        new
                        {
                            Id = new Guid("f09369fd-c8c9-49f7-acf7-eaceda3e974e"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 3, 5, 9 },
                            PartialPasswordHash = new byte[] { 138, 20, 177, 110 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 132, 4, 221, 157 }
                        },
                        new
                        {
                            Id = new Guid("aa696330-1a9a-43cd-a879-c680b3d8e5c8"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 7, 9, 10 },
                            PartialPasswordHash = new byte[] { 238, 62, 122, 198 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 145, 248, 135, 246 }
                        },
                        new
                        {
                            Id = new Guid("9c034f8a-07aa-46c4-87f4-9e270b252c0c"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 0, 6, 10 },
                            PartialPasswordHash = new byte[] { 161, 221, 142, 29 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 69, 254, 17, 19 }
                        },
                        new
                        {
                            Id = new Guid("c788f1da-e244-4552-aef4-782c17107888"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 0, 9, 10 },
                            PartialPasswordHash = new byte[] { 18, 241, 136, 249 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 140, 191, 234, 199 }
                        },
                        new
                        {
                            Id = new Guid("3675d236-4f70-40b6-ac84-33d9be97e3c4"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 2, 8, 10 },
                            PartialPasswordHash = new byte[] { 208, 37, 192, 131 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 232, 141, 118, 205 }
                        },
                        new
                        {
                            Id = new Guid("694dc4bb-081e-4e23-aefb-22fb2dbc42ff"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 1, 8, 9 },
                            PartialPasswordHash = new byte[] { 166, 149, 68, 78 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 205, 58, 16, 171 }
                        },
                        new
                        {
                            Id = new Guid("05b6b5e3-f5bd-4925-be93-e083f4671f95"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 0, 2, 8 },
                            PartialPasswordHash = new byte[] { 6, 15, 230, 89 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 217, 191, 48, 22 }
                        },
                        new
                        {
                            Id = new Guid("34c3f096-df37-44c1-997c-1f3047b4d3e3"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 3, 8, 9 },
                            PartialPasswordHash = new byte[] { 37, 54, 5, 24 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 140, 202, 54, 242 }
                        },
                        new
                        {
                            Id = new Guid("0954f5b9-c421-45f8-abe3-b20a2c6447b5"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            Mask = new[] { 0, 4, 7 },
                            PartialPasswordHash = new byte[] { 238, 210, 76, 79 },
                            PasswordStatus = 1,
                            Salt = new byte[] { 85, 151, 91, 200 }
                        });
                });

            modelBuilder.Entity("SafestBankServer.Core.Client.BankClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<string>("ClientNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdentityCardId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BankClients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            AddressId = new Guid("2a94861f-0741-4605-ad2d-23f1ea906249"),
                            ClientNumber = "1",
                            Email = "sekula.sebastian.kontakt@gmail.com",
                            IdentityCardId = new Guid("52f2eb1b-42e9-41fe-be4d-30082e93183a"),
                            Name = "Sebastian",
                            PESEL = "12345678901",
                            Surname = "Sekula"
                        });
                });

            modelBuilder.Entity("SafestBankServer.Core.Client.Data.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BankClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BankClientId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a94861f-0741-4605-ad2d-23f1ea906249"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            City = "Warszawa",
                            Country = "Poland",
                            HouseNumber = "39",
                            Street = "Grójecka",
                            ZipCode = "12-102"
                        });
                });

            modelBuilder.Entity("SafestBankServer.Core.Client.Data.IdentityCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BankClientId")
                        .HasColumnType("uuid");

                    b.Property<string>("CountryOfIssue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BankClientId")
                        .IsUnique();

                    b.ToTable("IdentityCards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52f2eb1b-42e9-41fe-be4d-30082e93183a"),
                            BankClientId = new Guid("1cf07fb7-f6bb-4012-a3fb-27fe2ddca732"),
                            CountryOfIssue = "Polska",
                            Number = "12121212",
                            Serie = "RXA",
                            Type = "DOWÓD POLSKI"
                        });
                });

            modelBuilder.Entity("SafestBankServer.Core.Auth.Passwords.PartialPassword", b =>
                {
                    b.HasOne("SafestBankServer.Core.Client.BankClient", null)
                        .WithMany("PartialPasswords")
                        .HasForeignKey("BankClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SafestBankServer.Core.Client.Data.Address", b =>
                {
                    b.HasOne("SafestBankServer.Core.Client.BankClient", null)
                        .WithOne("Address")
                        .HasForeignKey("SafestBankServer.Core.Client.Data.Address", "BankClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SafestBankServer.Core.Client.Data.IdentityCard", b =>
                {
                    b.HasOne("SafestBankServer.Core.Client.BankClient", null)
                        .WithOne("IdentityCard")
                        .HasForeignKey("SafestBankServer.Core.Client.Data.IdentityCard", "BankClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SafestBankServer.Core.Client.BankClient", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("IdentityCard")
                        .IsRequired();

                    b.Navigation("PartialPasswords");
                });
#pragma warning restore 612, 618
        }
    }
}
