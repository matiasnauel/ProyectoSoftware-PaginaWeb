using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapaAccesoDatos.Migrations
{
    public partial class VENTA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_cliente = table.Column<int>(nullable: false),
                    Id_carrito = table.Column<int>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
