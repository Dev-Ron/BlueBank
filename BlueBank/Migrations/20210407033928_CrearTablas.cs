using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBankAPI.Migrations
{
    public partial class CrearTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_TipoDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha_Modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaId = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Modificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_PersonaId",
                table: "Cuenta",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_CuentaId",
                table: "Movimiento",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoDocumentoId",
                table: "Persona",
                column: "TipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoDocumento");
        }
    }
}
