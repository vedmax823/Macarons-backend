using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIngredientsFromMainMacaron : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Macarons_Ingredients_IngredientId",
                table: "Macarons");

            migrationBuilder.DropIndex(
                name: "IX_Macarons_IngredientId",
                table: "Macarons");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Macarons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IngredientId",
                table: "Macarons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Macarons_IngredientId",
                table: "Macarons",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Macarons_Ingredients_IngredientId",
                table: "Macarons",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }
    }
}
