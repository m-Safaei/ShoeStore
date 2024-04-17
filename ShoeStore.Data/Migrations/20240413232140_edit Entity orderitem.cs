using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class editEntityorderitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_Products_ProductId",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orderItems",
                newName: "ProductItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "orderItems",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_Products_ProductId",
                table: "orderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
