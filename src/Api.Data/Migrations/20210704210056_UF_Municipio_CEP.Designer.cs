﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210704210056_UF_Municipio_CEP")]
    partial class UF_Municipio_CEP
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Domain.Entities.CEPEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<Guid>("CountyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CEP");

                    b.HasIndex("CountyID");

                    b.ToTable("CEP");
                });

            modelBuilder.Entity("Api.Domain.Entities.CountyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodIBGE")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<Guid>("UFId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CodIBGE");

                    b.HasIndex("UFId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("Api.Domain.Entities.UFEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FederateUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FederateUnit")
                        .IsUnique();

                    b.ToTable("UF");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5718),
                            FederateUnit = "AC",
                            Name = "Acre"
                        },
                        new
                        {
                            Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5770),
                            FederateUnit = "AL",
                            Name = "Alagoas"
                        },
                        new
                        {
                            Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5774),
                            FederateUnit = "AM",
                            Name = "Amazonas"
                        },
                        new
                        {
                            Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5777),
                            FederateUnit = "AP",
                            Name = "Amapá"
                        },
                        new
                        {
                            Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5779),
                            FederateUnit = "BA",
                            Name = "Bahia"
                        },
                        new
                        {
                            Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5781),
                            FederateUnit = "CE",
                            Name = "Ceará"
                        },
                        new
                        {
                            Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5783),
                            FederateUnit = "DF",
                            Name = "Distrito Federal"
                        },
                        new
                        {
                            Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5785),
                            FederateUnit = "ES",
                            Name = "Espírito Santo"
                        },
                        new
                        {
                            Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5788),
                            FederateUnit = "GO",
                            Name = "Goiás"
                        },
                        new
                        {
                            Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5790),
                            FederateUnit = "MA",
                            Name = "Maranhão"
                        },
                        new
                        {
                            Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5792),
                            FederateUnit = "MG",
                            Name = "Minas Gerais"
                        },
                        new
                        {
                            Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5794),
                            FederateUnit = "MS",
                            Name = "Mato Grosso do Sul"
                        },
                        new
                        {
                            Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5796),
                            FederateUnit = "MT",
                            Name = "Mato Grosso"
                        },
                        new
                        {
                            Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5800),
                            FederateUnit = "PA",
                            Name = "Pará"
                        },
                        new
                        {
                            Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5801),
                            FederateUnit = "PB",
                            Name = "Paraíba"
                        },
                        new
                        {
                            Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5804),
                            FederateUnit = "PE",
                            Name = "Pernambuco"
                        },
                        new
                        {
                            Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5806),
                            FederateUnit = "PI",
                            Name = "Piauí"
                        },
                        new
                        {
                            Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5808),
                            FederateUnit = "PR",
                            Name = "Paraná"
                        },
                        new
                        {
                            Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5810),
                            FederateUnit = "RJ",
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5812),
                            FederateUnit = "RN",
                            Name = "Rio Grande do Norte"
                        },
                        new
                        {
                            Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5815),
                            FederateUnit = "RO",
                            Name = "Rondônia"
                        },
                        new
                        {
                            Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5817),
                            FederateUnit = "RR",
                            Name = "Roraima"
                        },
                        new
                        {
                            Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5819),
                            FederateUnit = "RS",
                            Name = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5821),
                            FederateUnit = "SC",
                            Name = "Santa Catarina"
                        },
                        new
                        {
                            Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5824),
                            FederateUnit = "SE",
                            Name = "Sergipe"
                        },
                        new
                        {
                            Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5826),
                            FederateUnit = "SP",
                            Name = "São Paulo"
                        },
                        new
                        {
                            Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                            CreateAt = new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5861),
                            FederateUnit = "TO",
                            Name = "Tocantins"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfb40ab2-8e08-43a5-8219-1e36660130e3"),
                            CreateAt = new DateTime(2021, 7, 4, 18, 0, 55, 798, DateTimeKind.Local).AddTicks(9570),
                            Email = "administrator@hotmail.com",
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.CEPEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.CountyEntity", "County")
                        .WithMany("CEPs")
                        .HasForeignKey("CountyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Domain.Entities.CountyEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.UFEntity", "UF")
                        .WithMany("Countys")
                        .HasForeignKey("UFId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}