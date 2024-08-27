﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zoo_App_again.Data;

#nullable disable

namespace Zoo_App_again.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240202002627_LastMigrationOne")]
    partial class LastMigrationOne
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Zoo_App_again.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<double>("PricePerOne")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<int?>("animalPlaceId")
                        .HasColumnType("int");

                    b.Property<int?>("importsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("animalPlaceId");

                    b.HasIndex("importsId")
                        .IsUnique()
                        .HasFilter("[importsId] IS NOT NULL");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.AnimalPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("AnimalPlaces");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Cafe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Monthly_Rent")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Rent_Duration")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cafes");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Exports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HistoryOfProcess")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrganizationExportedTo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("OurExports");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<double>("PricePerKilo")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("importsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("importsId")
                        .IsUnique();

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Imports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HistoryOfProcess")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrganizationImportedFrom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("OurImports");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Museum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Founder")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("HistoricalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HistoryOfConstruction")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Museums");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Ticket_Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfReservation")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Ticket_Reservations");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<double>("Salary")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Animal", b =>
                {
                    b.HasOne("Zoo_App_again.Entities.AnimalPlace", "AnimalPlace")
                        .WithMany("Existing_Animals")
                        .HasForeignKey("animalPlaceId");

                    b.HasOne("Zoo_App_again.Entities.Imports", "imports")
                        .WithOne("Existing_Animals")
                        .HasForeignKey("Zoo_App_again.Entities.Animal", "importsId");

                    b.Navigation("AnimalPlace");

                    b.Navigation("imports");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Food", b =>
                {
                    b.HasOne("Zoo_App_again.Entities.Imports", "imports")
                        .WithOne("Foods")
                        .HasForeignKey("Zoo_App_again.Entities.Food", "importsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("imports");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.AnimalPlace", b =>
                {
                    b.Navigation("Existing_Animals");
                });

            modelBuilder.Entity("Zoo_App_again.Entities.Imports", b =>
                {
                    b.Navigation("Existing_Animals");

                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}