using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapaAccesoDatos.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinoVentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destino = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forma = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEstados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VentasReclamos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reclamo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasReclamos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Id_ventaReclamo = table.Column<int>(nullable: false),
                    Tipoestado = table.Column<int>(nullable: false),
                    TipoEstadoNavigatorId = table.Column<int>(nullable: true),
                    VentaReclamoNavigatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_TipoEstados_TipoEstadoNavigatorId",
                        column: x => x.TipoEstadoNavigatorId,
                        principalTable: "TipoEstados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estados_VentasReclamos_VentaReclamoNavigatorId",
                        column: x => x.VentaReclamoNavigatorId,
                        principalTable: "VentasReclamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_cliente = table.Column<int>(nullable: false),
                    Id_carrito = table.Column<int>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    Id_destinoventa = table.Column<int>(nullable: false),
                    Id_tomapago = table.Column<int>(nullable: false),
                    Id_estadoventa = table.Column<int>(nullable: false),
                    EstadoVentaNavigatorId = table.Column<int>(nullable: true),
                    FormaPagoNavigatorId = table.Column<int>(nullable: true),
                    DestinoVentaNavigatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Ventas_DestinoVentas_DestinoVentaNavigatorId",
                        column: x => x.DestinoVentaNavigatorId,
                        principalTable: "DestinoVentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Estados_EstadoVentaNavigatorId",
                        column: x => x.EstadoVentaNavigatorId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_FormaPagos_FormaPagoNavigatorId",
                        column: x => x.FormaPagoNavigatorId,
                        principalTable: "FormaPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estados_TipoEstadoNavigatorId",
                table: "Estados",
                column: "TipoEstadoNavigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_VentaReclamoNavigatorId",
                table: "Estados",
                column: "VentaReclamoNavigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_DestinoVentaNavigatorId",
                table: "Ventas",
                column: "DestinoVentaNavigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EstadoVentaNavigatorId",
                table: "Ventas",
                column: "EstadoVentaNavigatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FormaPagoNavigatorId",
                table: "Ventas",
                column: "FormaPagoNavigatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "DestinoVentas");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "FormaPagos");

            migrationBuilder.DropTable(
                name: "TipoEstados");

            migrationBuilder.DropTable(
                name: "VentasReclamos");
        }
    }
}
