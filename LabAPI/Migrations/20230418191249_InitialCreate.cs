using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENFERMEIROS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSTITUIÇÃO_ENSINO_FORMACAO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    COFENUF = table.Column<string>(name: "COFEN/UF", type: "nvarchar(max)", nullable: false),
                    NOME_COMPLETO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENERO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENFERMEIROS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MEDICOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INSTITUIÇÃO_ENSINO_FORMACAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRMUF = table.Column<string>(name: "CRM/UF", type: "nvarchar(max)", nullable: false),
                    ESPECIALIZACAO_CLINICA = table.Column<int>(type: "int", nullable: false),
                    ESTADO_NO_SISTEMA = table.Column<int>(type: "int", nullable: false),
                    TOTAL_ATENDIMENTOS = table.Column<int>(type: "int", nullable: false),
                    NOME_COMPLETO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENERO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTATO_EMERGENCIA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALERGIAS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUIDADOS_ESPECIAIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CONVENIO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    STATUS_ATENDIMENTO = table.Column<int>(type: "int", nullable: false),
                    TOTAL_ATENDIMENTOS = table.Column<int>(type: "int", nullable: false),
                    NOME_COMPLETO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENERO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ENFERMEIROS",
                columns: new[] { "ID", "COFEN/UF", "CPF", "DATA_NASCIMENTO", "GENERO", "INSTITUIÇÃO_ENSINO_FORMACAO", "NOME_COMPLETO", "TELEFONE" },
                values: new object[,]
                {
                    { 3, "186.566/SC", "132.147.698-20", new DateTime(1989, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "UFSC", "Mateus Raimundo Aragão", "48999251200" },
                    { 4, "162.780/SC", "825.497.397-01", new DateTime(1990, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "UDESC", "Sarah Isabelle", "48991002564" }
                });

            migrationBuilder.InsertData(
                table: "MEDICOS",
                columns: new[] { "ID", "CPF", "CRM/UF", "DATA_NASCIMENTO", "ESPECIALIZACAO_CLINICA", "ESTADO_NO_SISTEMA", "GENERO", "INSTITUIÇÃO_ENSINO_FORMACAO", "NOME_COMPLETO", "TELEFONE", "TOTAL_ATENDIMENTOS" },
                values: new object[,]
                {
                    { 1, "140.159.530-14", "215.630/RJ", new DateTime(1989, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Feminino", "URJ", "Julia Vitória Barros", "48999201511", 0 },
                    { 2, "198.230.852-99", "125.541/SC", new DateTime(1989, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, "Masculino", "UDESC", "Lorenzo Benedito Monteiro", "48992015021", 0 }
                });

            migrationBuilder.InsertData(
                table: "PACIENTES",
                columns: new[] { "ID", "CPF", "CONTATO_EMERGENCIA", "CONVENIO", "DATA_NASCIMENTO", "GENERO", "NOME_COMPLETO", "TELEFONE", "TOTAL_ATENDIMENTOS", "ALERGIAS", "CUIDADOS_ESPECIAIS", "STATUS_ATENDIMENTO" },
                values: new object[,]
                {
                    { 5, "523.252.349-08", "4833259547", "Bradesco Saude", new DateTime(1980, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Alexandre Lorenzo da Mota", "4828454720", 0, "[\"Rinite\"]", "[\"não possui\"]", 0 },
                    { 6, "142.154.935-28", "4899631200", "One Health", new DateTime(1996, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Gabrielly Vitória Sueli Lopes", "4830459633", 0, "[\"Asma Bronquica\"]", "[\"faz uso regular da bombinha\"]", 0 },
                    { 7, "670.534.738-48", "4836210056", "Unimed", new DateTime(1975, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Aurora Francisca Marcela Bernardes", "4833254796", 0, "[\"Leite e derivados\"]", "[\"faz reposição de hormonios\"]", 0 },
                    { 8, "709.924.665-80", "4833002100", "One Health", new DateTime(1969, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Manoel Renato Theo da Cunha", "4891224420", 0, "[\"Frutos do Mar\"]", "[\"não possui\"]", 0 },
                    { 9, "253.415.630-69", "4833256612", "Unimed", new DateTime(1991, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Bruna Rosângela Francisca", "4899951120", 0, "[\"Não possui\"]", "[\"não possui\"]", 0 },
                    { 10, "506.250.120-44", "4830459992", "Bradesco Saude", new DateTime(1993, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Luiz Gustavo Costa", "4899220000", 0, "[\"Urticária\"]", "[\"não possui\"]", 0 },
                    { 11, "513.327.137-93", "48999520021", "SulAmérica Saude", new DateTime(1989, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Mariana Daniela Aragão", "4833090054", 0, "[\"Rinite, Bronquite, Camarão\"]", "[\"não possui\"]", 0 },
                    { 12, "922.265.830-25", "4833149951", "Bradesco Saude", new DateTime(1972, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Emanuelly Regina", "48999195520", 0, "[\"Não possui\"]", "[\"não possui\"]", 0 },
                    { 13, "867.882.944-37", "4833133021", "One Health", new DateTime(1969, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "Jennifer Vanessa Marlene Peixoto", "48999000015", 0, "[\"Alergia a Niquel\"]", "[\"não possui\"]", 0 },
                    { 14, "750.120.356-20", "4830492210", "SulAmérica Saude", new DateTime(1981, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "Joaquim Leandro Julio Silva", "4899101220", 0, "[\"Camarão\"]", "[\"não possui\"]", 0 }
                });
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
        }
    }
}
