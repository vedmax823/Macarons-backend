using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicUrlToMacaron : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicUrl",
                table: "Macarons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicUrl",
                table: "Macarons");
        }
    }
}
