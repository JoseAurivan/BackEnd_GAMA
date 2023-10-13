using Infrastructure.DataBaseModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class SolicitacaoConfiguration : IEntityTypeConfiguration<DTOSolicitacao>
    {
        public void Configure(EntityTypeBuilder<DTOSolicitacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.NumeroProtocolo);
            builder.Property(x => x.StatusSolicitacao);
            builder.HasOne(x => x.SecretariaDestino).WithMany(x => x.Solicitacoes).HasForeignKey(x => x.SecretariaId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(x => x.SolicitadoPor).WithMany(x => x.Solicitacao).HasForeignKey(x => x.SolicitadoPorId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(x => x.AtendidoPor).WithOne().HasForeignKey<DTOSolicitacao>(x => x.AtendidoPorId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Property(x => x.Inicio);
            builder.Property(x => x.Fim);
           
        }
    }
}
