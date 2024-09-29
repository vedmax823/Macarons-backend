using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyIngredientsMaccaron : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Macarons_MacaronId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_MacaronId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MacaronId",
                table: "Ingredients");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMacaron");

            migrationBuilder.AddColumn<Guid>(
                name: "MacaronId",
                table: "Ingredients",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_MacaronId",
                table: "Ingredients",
                column: "MacaronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Macarons_MacaronId",
                table: "Ingredients",
                column: "MacaronId",
                principalTable: "Macarons",
                principalColumn: "Id");
        }
    }
}
