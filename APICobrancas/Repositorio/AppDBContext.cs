using APICobrancas.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace APICobrancas.Repositorio
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Cobranca> Cobrancas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cobranca>().Property(c => c.ID);
            modelBuilder.Entity<Cobranca>().Property(c => c.CPF).HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Cobranca>().Property(c => c.Valor).HasPrecision(15, 2).IsRequired();
            modelBuilder.Entity<Cobranca>().Property(c => c.DataVencimento).IsRequired();
        }
    }
}
