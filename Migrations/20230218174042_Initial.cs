using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Ponto_Back.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModulosApontamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosApontamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontosDiarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuloApontamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataApontamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    Minutos = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontosDiarios_ModulosApontamento_ModuloApontamentoId",
                        column: x => x.ModuloApontamentoId,
                        principalTable: "ModulosApontamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontosDiarios_ModuloApontamentoId",
                table: "PontosDiarios",
                column: "ModuloApontamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontosDiarios");

            migrationBuilder.DropTable(
                name: "ModulosApontamento");
        }
    }
}
