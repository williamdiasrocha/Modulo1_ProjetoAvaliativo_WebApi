/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabAPI.Context;
using LabAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAPI.DATA
{
    public static class DbInitializer
    {
        public static void Initialize(LabApiContext context)
        {
            context.Database.GetPendingMigrations();

            // Verifica se já existem registros na tabela Pessoas
            if (context.Pessoas.Any())
            {
                return; // se já existe, não faz nada.
            }

            var pacientes = new Paciente[]
            {
                new Paciente { Id = 5, NomeCompleto = "Alexandre Lorenzo da Mota", DataNascimento = new DateTime(1980, 11, 26), Genero = "Masculino", CPF = "523.252.349-08", Telefone = "4828454720", ContatoEmergencia = "4833259547", Alergias = "Rinite", CuidadosEspecificos = "não possui", Convenio = "Bradesco Saude"},

                    new Paciente { Id = 6, NomeCompleto = "Gabrielly Vitória Sueli Lopes", DataNascimento = new DateTime(1996, 07, 14), Genero = "Feminino", CPF = "142.154.935-28", Telefone = "4830459633", ContatoEmergencia = "4899631200", Alergias = "Asma Bronquica", CuidadosEspecificos = "faz uso regular da bombinha", Convenio = "One Health"},

                    new Paciente { Id = 7, NomeCompleto = "Aurora Francisca Marcela Bernardes", DataNascimento = new DateTime(1975, 02, 05), Genero = "Feminino", CPF = "670.534.738-48", Telefone = "4833254796", ContatoEmergencia = "4836210056", Alergias = "Leite e derivados", CuidadosEspecificos = "faz reposição de hormonios", Convenio = "Unimed"},

                    new Paciente { Id = 8, NomeCompleto = "Manoel Renato Theo da Cunha", DataNascimento = new DateTime(1969, 12, 25), Genero = "Masculino", CPF = "709.924.665-80", Telefone = "4891224420", ContatoEmergencia = "4833002100", Alergias = "Frutos do Mar", CuidadosEspecificos = "não possui", Convenio = "One Health"},

                    new Paciente { Id = 9, NomeCompleto = "Bruna Rosângela Francisca", DataNascimento = new DateTime(1991, 01, 31), Genero = "Feminino", CPF = "253.415.630-69", Telefone = "4899951120", ContatoEmergencia = "4833256612", Alergias = "Não possui", CuidadosEspecificos = "não possui", Convenio = "Unimed"},

                    new Paciente { Id = 10, NomeCompleto = "Luiz Gustavo Costa", DataNascimento = new DateTime(1993, 07, 09), Genero = "Masculino", CPF = "506.250.120-44", Telefone = "4899220000", ContatoEmergencia = "4830459992", Alergias = "Urticária", CuidadosEspecificos = "não possui", Convenio = "Bradesco Saude"},

                    new Paciente { Id = 11, NomeCompleto = "Mariana Daniela Aragão", DataNascimento = new DateTime(1989, 09, 19), Genero = "Feminino", CPF = "513.327.137-93", Telefone = "4833090054", ContatoEmergencia = "48999520021", Alergias = "Rinite, Bronquite", CuidadosEspecificos = "não possui", Convenio = "SulAmérica Saude"},

                    new Paciente { Id = 12, NomeCompleto = "Emanuelly Regina", DataNascimento = new DateTime(1972, 07, 10), Genero = "Feminino", CPF = "922.265.830-25", Telefone = "48999195520", ContatoEmergencia = "4833149951", Alergias = "Não possui", CuidadosEspecificos = "não possui", Convenio = "Bradesco Saude"},

                    new Paciente { Id = 13, NomeCompleto = "Jennifer Vanessa Marlene Peixoto", DataNascimento = new DateTime(1969, 12, 25), Genero = "Feminino", CPF = "867.882.944-37", Telefone = "48999000015", ContatoEmergencia = "4833133021", Alergias = "Alergia a Niquel", CuidadosEspecificos = "não possui", Convenio = "One Health"},

                    new Paciente { Id = 14, NomeCompleto = "Joaquim Leandro Julio Silva", DataNascimento = new DateTime(1981, 04, 26), Genero = "Masculino", CPF = "750.120.356-20", Telefone = "4899101220", ContatoEmergencia = "4830492210", Alergias = "Camarão", CuidadosEspecificos = "não possui", Convenio = "SulAmérica Saude"},
            };
            context.Pacientes.AddRange(pacientes);  
           
           // Verifica se existem enfermeiros cadastrados
           if (context.Enfermeiros.Any())
           {
            return; // se já existem, não faz nada.
           }

           var enfermeiros = new Enfermeiro[]
           {
                new Enfermeiro { Id = 3, NomeCompleto = "Mateus Raimundo Aragão", DataNascimento = new DateTime(1989, 11, 23), Genero = "Masculino", CPF = "132.147.698-20", Telefone = "48999251200", InstituicaoEnsinoFormacao = "UFSC", COFEN_UF = "186.566/SC"},

                new Enfermeiro { Id = 4, NomeCompleto = "Sarah Isabelle", DataNascimento = new DateTime(1990, 01, 15), Genero = "Feminino", CPF = "825.497.397-01", Telefone = "48991002564", InstituicaoEnsinoFormacao = "UDESC", COFEN_UF = "162.780/SC"},
           };
           context.Enfermeiros.AddRange(enfermeiros);

            //Verifica se já existem médicos cadastrados
           if (context.Medicos.Any())
           {
            return; // se já existem, não faz nada.
           }

           var medicos = new Medico[]
           {
                new Medico { Id = 1, NomeCompleto = "Julia Vitória Barros", DataNascimento = new DateTime(1989, 11, 23), Genero = "Feminino", CPF = "140.159.530-14", Telefone = "48999201511", InstituicaoEnsinoFormacao = "URJ", CRM_UF = "215.630/RJ", Especializacao_Clinica = Medico.EspecializacaoClinica.Clinico_Geral, EstadoNoSistema = true, TotalAtendimentos = 0},

                new Medico { Id = 2, NomeCompleto = "Lorenzo Benedito Monteiro", DataNascimento = new DateTime(1989, 11, 23), Genero = "Masculino", CPF = "198.230.852-99", Telefone = "48992015021", InstituicaoEnsinoFormacao = "UDESC", CRM_UF = "125.541/SC", Especializacao_Clinica = Medico.EspecializacaoClinica.Neurologia, EstadoNoSistema = true, TotalAtendimentos = 0}
           };
            context.Medicos.AddRange(medicos);
            context.SaveChanges();

        }
    }
} */