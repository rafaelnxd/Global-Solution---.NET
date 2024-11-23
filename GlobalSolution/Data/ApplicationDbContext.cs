
using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GlobalSolution.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<ConsumoEnergia> ConsumosEnergia { get; set; }
        public DbSet<ConfiguracaoAutomacao> ConfiguracoesAutomacao { get; set; }
        public DbSet<AlertaNotificacao> AlertasNotificacoes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite keys, relationships, and constraints if necessary

            base.OnModelCreating(modelBuilder);
        }
    }
}
