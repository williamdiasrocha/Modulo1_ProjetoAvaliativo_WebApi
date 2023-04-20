using LabAPI.DTO;
using LabAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;


namespace LabAPI.Models
{
    public class LabApiContext : DbContext
    {
    public LabApiContext(DbContextOptions<LabApiContext> options) : base(options)
        {
        
        }

    
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Enfermeiro> Enfermeiros { get; set; }
    

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