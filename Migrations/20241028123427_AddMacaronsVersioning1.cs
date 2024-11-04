using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class AddMacaronsVersioning1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMacaron");

            migrationBuilder.DropColumn(
                name: "AdvertismentPrice",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "IsCurrentlyUnavailable",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "IsXl",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "Macarons");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentVersionId",
                table: "Macarons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientId",
                table: "Macarons",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MacaronsVersionId",
                table: "Ingredients",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MacaronsVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Taste = table.Column<string>(type: "text", nullable: false),
                    PictureLink = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    AdvertismentPrice = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsXl = table.Column<bool>(type: "boolean", nullable: false),
                    IsCurrentlyAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    MacaronId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacaronsVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MacaronsVersions_Macarons_MacaronId",
                        column: x => x.MacaronId,
                        principalTable: "Macarons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Macarons_CurrentVersionId",
                table: "Macarons",
                column: "CurrentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Macarons_IngredientId",
                table: "Macarons",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MacaronsVersionId",
                table: "Ingredients",
                column: "MacaronsVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_MacaronsVersions_MacaronId",
                table: "MacaronsVersions",
                column: "MacaronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_MacaronsVersions_MacaronsVersionId",
                table: "Ingredients",
                column: "MacaronsVersionId",
                principalTable: "MacaronsVersions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Macarons_Ingredients_IngredientId",
                table: "Macarons",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Macarons_MacaronsVersions_CurrentVersionId",
                table: "Macarons",
                column: "CurrentVersionId",
                principalTable: "MacaronsVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_MacaronsVersions_MacaronsVersionId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Macarons_Ingredients_IngredientId",
                table: "Macarons");

            migrationBuilder.DropForeignKey(
                name: "FK_Macarons_MacaronsVersions_CurrentVersionId",
                table: "Macarons");

            migrationBuilder.DropTable(
                name: "MacaronsVersions");

            migrationBuilder.DropIndex(
                name: "IX_Macarons_CurrentVersionId",
                table: "Macarons");

            migrationBuilder.DropIndex(
                name: "IX_Macarons_IngredientId",
                table: "Macarons");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MacaronsVersionId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CurrentVersionId",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "MacaronsVersionId",
                table: "Ingredients");

            migrationBuilder.AddColumn<float>(
                name: "AdvertismentPrice",
                table: "Macarons",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Macarons",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "Macarons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Macarons",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Taste",
                table: "Macarons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IngredientMacaron",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MacaronsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMacaron", x => new { x.IngredientsId, x.MacaronsId });
                    table.ForeignKey(
                        name: "FK_IngredientMacaron_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMacaron_Macarons_MacaronsId",
                        column: x => x.MacaronsId,
                        principalTable: "Macarons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMacaron_MacaronsId",
                table: "IngredientMacaron",
                column: "MacaronsId");
        }
    }
}
