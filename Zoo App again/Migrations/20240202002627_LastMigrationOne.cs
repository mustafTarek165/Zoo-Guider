using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo_App_again.Migrations
{
    /// <inheritdoc />
    public partial class LastMigrationOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Monthly_Rent = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    Rent_Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Museums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    HistoryOfConstruction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Founder = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    HistoricalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurExports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationExportedTo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Classification = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    HistoryOfProcess = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurExports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurImports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classification = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    HistoryOfProcess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationImportedFrom = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    TotalPrice = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurImports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketType = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Job = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Salary = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classification = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PricePerOne = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    animalPlaceId = table.Column<int>(type: "int", nullable: true),
                    importsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalPlaces_animalPlaceId",
                        column: x => x.animalPlaceId,
                        principalTable: "AnimalPlaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Animals_OurImports_importsId",
                        column: x => x.importsId,
                        principalTable: "OurImports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    PricePerKilo = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    importsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_OurImports_importsId",
                        column: x => x.importsId,
                        principalTable: "OurImports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_animalPlaceId",
                table: "Animals",
                column: "animalPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_importsId",
                table: "Animals",
                column: "importsId",
                unique: true,
                filter: "[importsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_importsId",
                table: "Foods",
                column: "importsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Museums");

            migrationBuilder.DropTable(
                name: "OurExports");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Ticket_Reservations");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "AnimalPlaces");

            migrationBuilder.DropTable(
                name: "OurImports");
        }
    }
}
