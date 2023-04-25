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
    
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
    
