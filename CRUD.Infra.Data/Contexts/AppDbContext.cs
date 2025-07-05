using CRUD.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Telefone>? Telefones { get; set; }
        public DbSet<TipoTelefone>? TiposTelefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}