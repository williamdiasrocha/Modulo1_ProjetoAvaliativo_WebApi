using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    ID_PESSOA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_COMPLETO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENERO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.ID_PESSOA);
                });

            migrationBuilder.CreateTable(
                name: "ENFERMEIROS",
                columns: table => new
                {
                    ID_PESSOA = table.Column<int>(type: "int", nullable: false),
                    ID_ENFERMEIRO = table.Column<int>(type: "int", nullable: false),
                    INSTITUIÇÃO_ENSINO_FORMACAO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    COFENUF = table.Column<string>(name: "COFEN/UF", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENFERMEIROS", x => x.ID_PESSOA);
                    table.ForeignKey(
                        name: "FK_ENFERMEIROS_PESSOA_ID_PESSOA",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICOS",
                columns: table => new
                {
                    ID_PESSOA = table.Column<int>(type: "int", nullable: false),
                    ID_MEDICO = table.Column<int>(type: "int", nullable: false),
                    INSTITUIÇÃO_ENSINO_FORMACAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRMUF = table.Column<string>(name: "CRM/UF", type: "nvarchar(max)", nullable: false),
                    ESPECIALIZACAO_CLINICA = table.Column<int>(type: "int", nullable: false),
                    ESTADO_NO_SISTEMA = table.Column<int>(type: "int", nullable: false),
                    TOTAL_ATENDIMENTOS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS", x => x.ID_PESSOA);
                    table.ForeignKey(
                        name: "FK_MEDICOS_PESSOA_ID_PESSOA",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    ID_PESSOA = table.Column<int>(type: "int", nullable: false),
                    ID_PACIENTE = table.Column<int>(type: "int", nullable: false),
                    CONTATO_EMERGENCIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALERGIAS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUIDADOS_ESPECIAIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONVENIO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    StatusAtendId = table.Column<int>(type: "int", nullable: false),
                    STATUS_ATENDIMENTO = table.Column<int>(type: "int", nullable: false),
                    TOTAL_ATENDIMENTOS = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.ID_PESSOA);
                    table.ForeignKey(
                        name: "FK_PACIENTES_PESSOA_ID_PESSOA",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ATENDIMENTOS",
                columns: table => new
                {
                    ID_ATEND = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteIdPessoa = table.Column<int>(type: "int", nullable: true),
                    MedicoIdPessoa = table.Column<int>(type: "int", nullable: true),
                    DATA_ATEND = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATENDIMENTOS", x => x.ID_ATEND);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTOS_MEDICOS_MedicoIdPessoa",
                        column: x => x.MedicoIdPessoa,
                        principalTable: "MEDICOS",
                        principalColumn: "ID_PESSOA");
                    table.ForeignKey(
                        name: "FK_ATENDIMENTOS_PACIENTES_PacienteIdPessoa",
                        column: x => x.PacienteIdPessoa,
                        principalTable: "PACIENTES",
                        principalColumn: "ID_PESSOA");
                });

            migrationBuilder.InsertData(
                table: "PESSOA",
                columns: new[] { "ID_PESSOA", "CPF", "DATA_NASCIMENTO", "GENERO", "NOME_COMPLETO", "TELEFONE" },
                values: new object[,]
                {
                    { 1, "140.159.530-14", new DateTime(1989, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Julia Vitória Barros", "48999201511" },
                    { 2, "198.230.852-99", new DateTime(1989, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Lorenzo Benedito Monteiro", "48992015021" },
                    { 3, "132.147.698-20", new DateTime(1989, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Mateus Raimundo Aragão", "48999251200" },
                    { 4, "825.497.397-01", new DateTime(1990, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Sarah Isabelle", "48991002564" },
                    { 5, "523.252.349-08", new DateTime(1980, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Alexandre Lorenzo da Mota", "4828454720" },
                    { 6, "142.154.935-28", new DateTime(1996, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Gabrielly Vitória Sueli Lopes", "4830459633" },
                    { 7, "670.534.738-48", new DateTime(1975, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Aurora Francisca Marcela Bernardes", "4833254796" },
                    { 8, "709.924.665-80", new DateTime(1969, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Manoel Renato Theo da Cunha", "4891224420" },
                    { 9, "253.415.630-69", new DateTime(1991, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Bruna Rosângela Francisca", "4899951120" },
                    { 10, "506.250.120-44", new DateTime(1993, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luiz Gustavo Costa", "4899220000" },
                    { 11, "513.327.137-93", new DateTime(1989, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Mariana Daniela Aragão", "4833090054" },
                    { 12, "922.265.830-25", new DateTime(1972, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Emanuelly Regina", "48999195520" },
                    { 13, "867.882.944-37", new DateTime(1969, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Jennifer Vanessa Marlene Peixoto", "48999000015" },
                    { 14, "750.120.356-20", new DateTime(1981, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Joaquim Leandro Julio Silva", "4899101220" }
                });

            migrationBuilder.InsertData(
                table: "ENFERMEIROS",
                columns: new[] { "ID_PESSOA", "COFEN/UF", "ID_ENFERMEIRO", "INSTITUIÇÃO_ENSINO_FORMACAO" },
                values: new object[,]
                {
                    { 3, "186.566/SC", 0, "UFSC" },
                    { 4, "162.780/SC", 0, "UDESC" }
                });

            migrationBuilder.InsertData(
                table: "MEDICOS",
                columns: new[] { "ID_PESSOA", "CRM/UF", "ESPECIALIZACAO_CLINICA", "ESTADO_NO_SISTEMA", "ID_MEDICO", "INSTITUIÇÃO_ENSINO_FORMACAO", "TOTAL_ATENDIMENTOS" },
                values: new object[,]
                {
                    { 1, "215.630/RJ", 1, 1, 0, "URJ", 0 },
                    { 2, "125.541/SC", 5, 1, 0, "UDESC", 0 }
                });

            migrationBuilder.InsertData(
                table: "PACIENTES",
                columns: new[] { "ID_PESSOA", "ALERGIAS", "CONTATO_EMERGENCIA", "CONVENIO", "CUIDADOS_ESPECIAIS", "ID_PACIENTE", "StatusAtendId", "StatusId", "TOTAL_ATENDIMENTOS", "STATUS_ATENDIMENTO" },
                values: new object[,]
                {
                    { 5, "Rinite", "4833259547", "Bradesco Saude", "não possui", 0, 0, 0, 0, 0 },
                    { 6, "Asma Bronquica", "4899631200", "One Health", "faz uso regular da bombinha", 0, 0, 0, 0, 0 },
                    { 7, "Leite e derivados", "4836210056", "Unimed", "faz reposição de hormonios", 0, 0, 0, 0, 0 },
                    { 8, "Frutos do Mar", "4833002100", "One Health", "não possui", 0, 0, 0, 0, 0 },
                    { 9, "Não possui", "4833256612", "Unimed", "não possui", 0, 0, 0, 0, 0 },
                    { 10, "Urticária", "4830459992", "Bradesco Saude", "não possui", 0, 0, 0, 0, 0 },
                    { 11, "Rinite, Bronquite, Camarão", "48999520021", "SulAmérica Saude", "não possui", 0, 0, 0, 0, 0 },
                    { 12, "Não possui", "4833149951", "Bradesco Saude", "não possui", 0, 0, 0, 0, 0 },
                    { 13, "Alergia a Niquel", "4833133021", "One Health", "não possui", 0, 0, 0, 0, 0 },
                    { 14, "Camarão", "4830492210", "SulAmérica Saude", "não possui", 0, 0, 0, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTOS_MedicoIdPessoa",
                table: "ATENDIMENTOS",
                column: "MedicoIdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTOS_PacienteIdPessoa",
                table: "ATENDIMENTOS",
                column: "PacienteIdPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATENDIMENTOS");

            migrationBuilder.DropTable(
                name: "ENFERMEIROS");

            migrationBuilder.DropTable(
                name: "MEDICOS");

            migrationBuilder.DropTable(
                name: "PACIENTES");

            migrationBuilder.DropTable(
                name: "PESSOA");
        }
    }
}
