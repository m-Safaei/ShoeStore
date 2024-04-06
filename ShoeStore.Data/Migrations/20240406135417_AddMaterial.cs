using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Material_MaterialId",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "ProductItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MaterialId",
                table: "Products",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Materials_MaterialId",
                table: "ProductItems",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Materials_MaterialId",
                table: "Products",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Materials_MaterialId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Materials_MaterialId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MaterialId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Material_MaterialId",
                table: "ProductItems",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
