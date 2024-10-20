using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class AddMacaronBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MacaronsBoxId",
                table: "Macarons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MacaronsBoxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PictureLink = table.Column<string>(type: "text", nullable: false),
                    IsXl = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    NumberOfMacarons = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    AdvertismentPrice = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacaronsBoxes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Macarons_MacaronsBoxId",
                table: "Macarons",
                column: "MacaronsBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Macarons_MacaronsBoxes_MacaronsBoxId",
                table: "Macarons",
                column: "MacaronsBoxId",
                principalTable: "MacaronsBoxes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Macarons_MacaronsBoxes_MacaronsBoxId",
                table: "Macarons");

            migrationBuilder.DropTable(
                name: "MacaronsBoxes");

            migrationBuilder.DropIndex(
                name: "IX_Macarons_MacaronsBoxId",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "MacaronsBoxId",
                table: "Macarons");
        }
    }
}
