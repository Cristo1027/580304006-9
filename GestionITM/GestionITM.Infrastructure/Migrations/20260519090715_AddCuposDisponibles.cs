using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionITM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCuposDisponibles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuposDisponibles",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuposDisponibles",
                table: "Cursos");
        }
    }
}
