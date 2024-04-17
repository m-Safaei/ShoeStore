using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEmailFieldFromUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_Products_ProductId",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_orderItems_OrderItemId",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_OrderItemId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "ProductItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orderItems",
                newName: "ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems",
                newName: "IX_orderItems_ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_ProductItems_ProductItemId",
                table: "orderItems",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_ProductItems_ProductItemId",
                table: "orderItems");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "orderItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_ProductItemId",
                table: "orderItems",
                newName: "IX_orderItems_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_OrderItemId",
                table: "ProductItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_Products_ProductId",
                table: "orderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_orderItems_OrderItemId",
                table: "ProductItems",
                column: "OrderItemId",
                principalTable: "orderItems",
                principalColumn: "Id");
        }
    }
}
