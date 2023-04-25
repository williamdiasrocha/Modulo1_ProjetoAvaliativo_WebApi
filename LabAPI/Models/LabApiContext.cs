using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    public DbSet<AtendimentoModel> Atendimento { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Paciente>()
            .HasNoKey()
            .Property(Paciente => Paciente.Alergias)
            .HasConversion(new ValueConverter<List<string>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v))); 
            
            modelBuilder.Entity<Paciente>()
            .HasNoKey()
            .Property(Paciente => Paciente.CuidadosEspecificos)
            .HasConversion(new ValueConverter<List<string>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v)));  */

            modelBuilder.Seed();
        }
    }
    
}
    
