using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "facturaCompras",
                columns: table => new
                {
                    FacturaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    TotalDescontado = table.Column<double>(type: "float", nullable: false),
                    TotalIVA = table.Column<double>(type: "float", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProveedorId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturaCompras", x => x.FacturaId);
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    FacturaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    TotalDescontado = table.Column<double>(type: "float", nullable: false),
                    TotalIVA = table.Column<double>(type: "float", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteresadoId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.FacturaId);
                });

            migrationBuilder.CreateTable(
                name: "interesados",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interesados", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "detalles",
                columns: table => new
                {
                    DetalleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    ValorProducto = table.Column<double>(type: "float", nullable: false),
                    TotalDescontado = table.Column<double>(type: "float", nullable: false),
                    TotalIVA = table.Column<double>(type: "float", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    FacturaCompraFacturaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FacturaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_detalles_facturaCompras_FacturaCompraFacturaId",
                        column: x => x.FacturaCompraFacturaId,
                        principalTable: "facturaCompras",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalles_facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "facturas",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    Iva = table.Column<double>(type: "float", nullable: false),
                    TotalDescuento = table.Column<double>(type: "float", nullable: false),
                    TotalIva = table.Column<double>(type: "float", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_productos_proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "proveedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalles_FacturaCompraFacturaId",
                table: "detalles",
                column: "FacturaCompraFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_FacturaId",
                table: "detalles",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_IdProveedor",
                table: "productos",
                column: "IdProveedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalles");

            migrationBuilder.DropTable(
                name: "interesados");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "facturaCompras");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "proveedores");
        }
    }
}
