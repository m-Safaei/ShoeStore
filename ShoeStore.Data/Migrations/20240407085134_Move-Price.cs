using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class MovePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ProductItemImage",
                table: "ProductItems");

            migrationBuilder.RenameColumn(
                name: "ProductImages",
                table: "Products",
                newName: "ProductImage");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_ProductId",
                table: "ProductFeature",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeature");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Products",
                newName: "ProductImages");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductItemImage",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
