using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class AddMacaronsBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsCurrentlyUnavailable = table.Column<bool>(type: "boolean", nullable: false),
                    PublicUrl = table.Column<string>(type: "text", nullable: false),
                    IsFixed = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacaronsBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmallMacaronsSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    MacaronId = table.Column<Guid>(type: "uuid", nullable: false),
                    MacaronsBoxId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallMacaronsSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmallMacaronsSets_MacaronsBoxes_MacaronsBoxId",
                        column: x => x.MacaronsBoxId,
                        principalTable: "MacaronsBoxes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SmallMacaronsSets_Macarons_MacaronId",
                        column: x => x.MacaronId,
                        principalTable: "Macarons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmallMacaronsSets_MacaronId",
                table: "SmallMacaronsSets",
                column: "MacaronId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallMacaronsSets_MacaronsBoxId",
                table: "SmallMacaronsSets",
                column: "MacaronsBoxId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmallMacaronsSets");

            migrationBuilder.DropTable(
                name: "MacaronsBoxes");
        }
    }
}
