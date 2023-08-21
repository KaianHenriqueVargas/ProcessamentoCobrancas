using APIClientes.Dominio;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Repositorio
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().HasKey(p => p.ID);
            modelBuilder.Entity<Pessoa>().Property(p => p.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(p => p.UF).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Pessoa>().Property(p => p.CPF).HasMaxLength(11).IsRequired();

        }
    }
}
