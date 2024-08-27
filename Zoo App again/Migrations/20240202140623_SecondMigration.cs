using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo_App_again.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classification",
                table: "OurExports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "OurExports",
                type: "VARCHAR(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
