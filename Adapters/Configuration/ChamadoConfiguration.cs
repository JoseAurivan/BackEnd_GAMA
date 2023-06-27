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
    internal class ChamadoConfiguration : IEntityTypeConfiguration<DTOChamado>
    {
        public void Configure(EntityTypeBuilder<DTOChamado> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Solicitacao).WithOne().HasForeignKey<DTOChamado>(x => x.SolicitacaoId);
            builder.Property(x => x.StatusAtendimento);
            builder.Property(x => x.Telefone);
        }
    }
}
