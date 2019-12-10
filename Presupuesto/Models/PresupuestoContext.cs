using Microsoft.EntityFrameworkCore;

namespace Presupuesto.Models
{
    public class PresupuestoContext : DbContext
    {
        public PresupuestoContext(DbContextOptions<PresupuestoContext> options)
        : base(options)
        { }
        public DbSet<AnalisisUnitario> AnalisisUnitario { get; set; }
        public DbSet<CostoIndirecto> CostoIndirecto { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<RecursoBasico> RecursoBasico { get; set; }
        public DbSet<Detalle> Detalle { get; set; }
        public DbSet<Capitulo> Capitulo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalisisUnitario>()
                .HasMany(b => b.Detalles)
                .WithOne();

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Detalles)
                .WithOne();
            

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();            
        }

    }
}
