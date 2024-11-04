using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonMacaron.Migrations
{
    /// <inheritdoc />
    public partial class AddVersioningToMacaronsBoxes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmallMacaronsSets_MacaronsBoxes_MacaronsBoxId",
                table: "SmallMacaronsSets");

            migrationBuilder.DropColumn(
                name: "AdvertismentPrice",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "IsCurrentlyUnavailable",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "IsFixed",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "IsXl",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "NumberOfMacarons",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MacaronsBoxes");

            migrationBuilder.RenameColumn(
                name: "MacaronsBoxId",
                table: "SmallMacaronsSets",
                newName: "MacaronsBoxVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_SmallMacaronsSets_MacaronsBoxId",
                table: "SmallMacaronsSets",
                newName: "IX_SmallMacaronsSets_MacaronsBoxVersionId");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentVersionId",
                table: "MacaronsBoxes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MacaronsBoxVersions",
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
                    IsFixed = table.Column<bool>(type: "boolean", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    MacaronsBoxId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacaronsBoxVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MacaronsBoxVersions_MacaronsBoxes_MacaronsBoxId",
                        column: x => x.MacaronsBoxId,
                        principalTable: "MacaronsBoxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MacaronsBoxes_CurrentVersionId",
                table: "MacaronsBoxes",
                column: "CurrentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_MacaronsBoxVersions_MacaronsBoxId",
                table: "MacaronsBoxVersions",
                column: "MacaronsBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_MacaronsBoxes_MacaronsBoxVersions_CurrentVersionId",
                table: "MacaronsBoxes",
                column: "CurrentVersionId",
                principalTable: "MacaronsBoxVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmallMacaronsSets_MacaronsBoxVersions_MacaronsBoxVersionId",
                table: "SmallMacaronsSets",
                column: "MacaronsBoxVersionId",
                principalTable: "MacaronsBoxVersions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MacaronsBoxes_MacaronsBoxVersions_CurrentVersionId",
                table: "MacaronsBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_SmallMacaronsSets_MacaronsBoxVersions_MacaronsBoxVersionId",
                table: "SmallMacaronsSets");

            migrationBuilder.DropTable(
                name: "MacaronsBoxVersions");

            migrationBuilder.DropIndex(
                name: "IX_MacaronsBoxes_CurrentVersionId",
                table: "MacaronsBoxes");

            migrationBuilder.DropColumn(
                name: "CurrentVersionId",
                table: "MacaronsBoxes");

            migrationBuilder.RenameColumn(
                name: "MacaronsBoxVersionId",
                table: "SmallMacaronsSets",
                newName: "MacaronsBoxId");

            migrationBuilder.RenameIndex(
                name: "IX_SmallMacaronsSets_MacaronsBoxVersionId",
                table: "SmallMacaronsSets",
                newName: "IX_SmallMacaronsSets_MacaronsBoxId");

            migrationBuilder.AddColumn<float>(
                name: "AdvertismentPrice",
                table: "MacaronsBoxes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MacaronsBoxes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyUnavailable",
                table: "MacaronsBoxes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixed",
                table: "MacaronsBoxes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsXl",
                table: "MacaronsBoxes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MacaronsBoxes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMacarons",
                table: "MacaronsBoxes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "MacaronsBoxes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "MacaronsBoxes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_SmallMacaronsSets_MacaronsBoxes_MacaronsBoxId",
                table: "SmallMacaronsSets",
                column: "MacaronsBoxId",
                principalTable: "MacaronsBoxes",
                principalColumn: "Id");
        }
    }
}
