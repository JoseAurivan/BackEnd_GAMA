using Core.Entities;
using Infrastructure.DataBaseModels.Entities;
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
        public DbSet<DTOCidadao>? Cidadoes { get; set; }
        public DbSet<DTOServidor>? Servidores { get; set; }
        public DbSet<DTOChamado>? Chamados { get; set; }
        public DbSet<DTOEndereco>? Enderecos { get; set; }
        public DbSet<DTOCestaBasica>? CestaBasicas { get; set; }
        public DbSet<DTOReclamacao>? Reclamacoes { get; set; }
        public DbSet<DTOFamilia>? Familias { get; set; }
        public DbSet<DTOSecretaria>? Secretarias { get; set; }
        public DbSet<DTOCargo>? Cargos { get; set; }
        public DbSet<DTOUser>? Users { get; set; }
        public DbSet<DTOSolicitacao> Solicitacoes { get; set; }



        public Task SaveChangesAsync() => SaveChangesAsync(default);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer("Server=localhost,10001;Database=GAMA_DB;" +
                "User Id=sa;Password=YourStrongPassword*;Trusted_Connection=false;" +
                " TrustServerCertificate=True; MultipleActiveResultSets=true");
           
        }
    }
}
