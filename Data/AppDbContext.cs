using ClyvoDayApiDocker.Models;
using Microsoft.EntityFrameworkCore;

namespace ClyvoDayApiDocker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AnimalEstimacao> AnimaisEstimacao { get; set; }
        public DbSet<Tutores> Tutores { get; set; }
        public DbSet<Veterinario> Veterinarios{ get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<MonitoramentoAnimal> Monitoramentos{ get; set; }
        public DbSet<EventoCuidado> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalEstimacao>().HasOne<Tutores>().WithMany(t => t.AnimaisEstimacao).HasForeignKey(p => p.TutoresId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EventoCuidado>().HasOne(e => e.AnimalEstimacao).WithMany().HasForeignKey(e => e.AnimalEstimacaoId);
            modelBuilder.Entity<Veterinario>().HasOne(v => v.Clinica).WithMany(c => c.Veterinarios).HasForeignKey(v => v.ClinicaId);
            modelBuilder.Entity<AnimalEstimacao>().Property(p => p.Weight).HasPrecision(10, 2);

        }
    }
}

////modelBuilder.Entity<Veterinarian>().HasOne<Clinic>().WithMany(c => c.Veterinarians).HasForeignKey(v => v.ClinicId);