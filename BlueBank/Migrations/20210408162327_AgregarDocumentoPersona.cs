using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBankAPI.Migrations
{
    public partial class AgregarDocumentoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Persona");
        }
    }
}
