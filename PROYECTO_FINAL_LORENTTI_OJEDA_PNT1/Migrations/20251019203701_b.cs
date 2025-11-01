using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarritoItems_Carrito_CarritoID",
                table: "CarritoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoItems_Productos_ProductoID",
                table: "CarritoItems");

            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "CarritoItems");

            migrationBuilder.RenameColumn(
                name: "ProductoID",
                table: "CarritoItems",
                newName: "ProductoId");

            migrationBuilder.RenameColumn(
                name: "CarritoID",
                table: "CarritoItems",
                newName: "CarritoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CarritoItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CarritoItems_ProductoID",
                table: "CarritoItems",
                newName: "IX_CarritoItems_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_CarritoItems_CarritoID",
                table: "CarritoItems",
                newName: "IX_CarritoItems_CarritoId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Carrito",
                newName: "Id");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "CarritoItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Carrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Usuario_UsuarioId",
                table: "Carrito",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoItems_Carrito_CarritoId",
                table: "CarritoItems",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoItems_Productos_ProductoId",
                table: "CarritoItems",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Usuario_UsuarioId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoItems_Carrito_CarritoId",
                table: "CarritoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoItems_Productos_ProductoId",
                table: "CarritoItems");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_UsuarioId",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "CarritoItems");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Carrito");

            migrationBuilder.RenameColumn(
                name: "ProductoId",
                table: "CarritoItems",
                newName: "ProductoID");

            migrationBuilder.RenameColumn(
                name: "CarritoId",
                table: "CarritoItems",
                newName: "CarritoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarritoItems",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CarritoItems_ProductoId",
                table: "CarritoItems",
                newName: "IX_CarritoItems_ProductoID");

            migrationBuilder.RenameIndex(
                name: "IX_CarritoItems_CarritoId",
                table: "CarritoItems",
                newName: "IX_CarritoItems_CarritoID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carrito",
                newName: "ID");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitario",
                table: "CarritoItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoItems_Carrito_CarritoID",
                table: "CarritoItems",
                column: "CarritoID",
                principalTable: "Carrito",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoItems_Productos_ProductoID",
                table: "CarritoItems",
                column: "ProductoID",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
