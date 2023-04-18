using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PESSOAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_COMPLETO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENERO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ENFERMEIROS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    INSTITUIÇÃO_ENSINO_FORMACAO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    COFENUF = table.Column<string>(name: "COFEN/UF", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENFERMEIROS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ENFERMEIROS_PESSOAS_ID",
                        column: x => x.ID,
                        principalTable: "PESSOAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    INSTITUIÇÃO_ENSINO_FORMACAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRMUF = table.Column<string>(name: "CRM/UF", type: "nvarchar(max)", nullable: false),
                    ESPECIALIZACAO_CLINICA = table.Column<int>(type: "int", nullable: false),
                    ESTADO_NO_SISTEMA = table.Column<bool>(type: "bit", nullable: false),
                    TOTAL_ATENDIMENTOS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MEDICOS_PESSOAS_ID",
                        column: x => x.ID,
                        principalTable: "PESSOAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CONTATO_EMERGENCIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALERGIAS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CUIDADOS_ESPECIAIS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CONVENIO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    STATUS_ATENDIMENTO = table.Column<int>(type: "int", nullable: false),
                    TOTAL_ATENDIMENTOS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PACIENTES_PESSOAS_ID",
                        column: x => x.ID,
                        principalTable: "PESSOAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_CPF",
                table: "PESSOAS",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENFERMEIROS");

            migrationBuilder.DropTable(
                name: "MEDICOS");

            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "PESSOAS");
        }
    }
}
