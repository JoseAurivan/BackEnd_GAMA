using Core.Entities;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Context:DbContext
    {
        public DbSet<Cidadao>? Cidadoes { get; set; }
        public DbSet<Servidor>? Servidores { get; set; }
        public DbSet<Chamado>? Chamados { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }
        public DbSet<CestaBasica>? CestaBasicas { get; set; }
        public DbSet<Reclamacao>? Reclamacoes { get; set; }
        public DbSet<Familia>? Familias { get; set; }
        public DbSet<Secretaria>? Secretarias { get; set; }
        public DbSet<Cargo>? Cargos { get; set; }



        public Task SaveChangesAsync() => SaveChangesAsync(default);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(s => s.Id);
            modelBuilder.Entity<User>().UseTpcMappingStrategy();

            modelBuilder.Entity<Solicitacao>().HasKey(s => s.Id);
            modelBuilder.Entity<Solicitacao>().UseTpcMappingStrategy();

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer("Server=localhost,10001;Database=GAMA_DB;User Id=sa;Password=YourStrongPassword*;Trusted_Connection=false; TrustServerCertificate=True; MultipleActiveResultSets=true");
           
        }
    }
}
