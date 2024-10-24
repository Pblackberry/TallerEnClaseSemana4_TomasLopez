using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerEnClaseSemana4_TomasLopez.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugador_Equipos_EquipoIdEquipo",
                table: "Jugador");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoIdEquipo",
                table: "Jugador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugador_Equipos_EquipoIdEquipo",
                table: "Jugador",
                column: "EquipoIdEquipo",
                principalTable: "Equipos",
                principalColumn: "IdEquipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugador_Equipos_EquipoIdEquipo",
                table: "Jugador");

            migrationBuilder.AlterColumn<int>(
                name: "EquipoIdEquipo",
                table: "Jugador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jugador_Equipos_EquipoIdEquipo",
                table: "Jugador",
                column: "EquipoIdEquipo",
                principalTable: "Equipos",
                principalColumn: "IdEquipo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
