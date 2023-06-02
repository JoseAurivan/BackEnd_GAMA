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
    internal class ChamadoConfiguration : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder.Property(x => x.Descricao);
            builder.HasOne(x => x.SolicitadoPor).WithOne().HasForeignKey<Chamado>(x => x.SolicitanteId);
            builder.HasOne(x => x.SecretariaDestino).WithMany();
            builder.HasOne(x => x.AtendidoPor).WithOne().HasForeignKey<Chamado>(x => x.AtendenteId);
            builder.Property(x => x.NumeroProtocolo);
            builder.Property(x => x.Inicio);
            builder.Property(x => x.Fim);
            builder.Property(x => x.StatusAtendimento);
            builder.Property(x => x.StatusSolicitacao);
            builder.Property(x => x.Telefone);
        }
    }
}
