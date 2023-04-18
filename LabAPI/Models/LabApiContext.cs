using LabAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LabAPI.Context
{
    public class LabApiContext : DbContext
    {
    public LabApiContext(DbContextOptions<LabApiContext> options) : base(options)
        {
        
        }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Enfermeiro> Enfermeiros { get; set; }


   
    }
}
