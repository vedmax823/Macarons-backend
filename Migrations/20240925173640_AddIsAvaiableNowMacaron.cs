using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAvaiableNowMacaron : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyUnavailable",
                table: "Macarons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsXl",
                table: "Macarons",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrentlyUnavailable",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "IsXl",
                table: "Macarons");
        }
    }
}
