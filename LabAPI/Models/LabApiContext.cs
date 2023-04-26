using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabApi.DTOS;
using Microsoft.EntityFrameworkCore;
using static LabApi.Models.PacienteModel;

namespace LabApi.Models
{
    public class LabApiContext : DbContext
    {
         public LabApiContext(DbContextOptions<LabApiContext> options) : base(options)
        {
        
        }

    
    public DbSet<PacienteModel> Pacientes { get; set; }
    public DbSet<MedicoModel> Medicos { get; set; }
    public DbSet<EnfermeiroModel> Enfermeiros { get; set; }
    public DbSet<AtendimentoModel> Atendimentos { get; set; }
    
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaModel>()
                .ToTable("PESSOA")
                .HasKey(p => p.IdPessoa);

            modelBuilder.Entity<PessoaModel>()
                .Property(p => p.IdPessoa)
                .HasColumnName("ID_PESSOA")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PessoaModel>()
                .Property(p => p.NomeCompleto)
                .HasColumnName("NOME_COMPLETO")
                .IsRequired();

            modelBuilder.Entity<PessoaModel>()
                .Property(p => p.Genero)
                .HasColumnName("GENERO")
                .HasMaxLength(25);

            modelBuilder.Entity<PessoaModel>()
                .Property(p => p.DataNascimento)
                .HasColumnName("DATA_NASCIMENTO")
                .IsRequired();

            modelBuilder.Entity<PessoaModel>()
                .Property(p => p.CPF)
                .HasColumnName("CPF")
                .IsRequired();

            modelBuilder.Entity<PessoaModel>()
                .Property(p => p.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(15);

            
            
           /*  modelBuilder.Entity<PacienteModel>()
                .Property(x => x.Alergias)
                .HasConversion(c => string.Join(',', c),
                               c => c.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            modelBuilder.Entity<PacienteModel>()
                .Property(x => x.CuidadosEspecificos)
                .HasConversion(c => string.Join(',', c),
                               c => c.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()); */

            modelBuilder.Seed();
        }
    }
    
}
    
