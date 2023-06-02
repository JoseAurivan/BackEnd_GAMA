using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class CestaConfiguration : IEntityTypeConfiguration<CestaBasica>
    {
        public void Configure(EntityTypeBuilder<CestaBasica> builder)
        {
            builder.Property(x => x.SituacaoDescricao);
            builder.Property(x => x.Descricao);
            builder.HasOne(x => x.SolicitadoPor).WithOne();
            builder.HasOne(x => x.AtendidoPor).WithOne();
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<CestaBasica>(x => x.EnderecoId);
            builder.Property(x => x.NumeroProtocolo);
            builder.Property(x => x.Inicio);
            builder.Property(x => x.Fim);
            builder.Property(x => x.StatusSolicitacao);
        }
    }
}
