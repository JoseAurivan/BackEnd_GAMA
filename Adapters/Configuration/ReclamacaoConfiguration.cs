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
    internal class ReclamacaoConfiguration : IEntityTypeConfiguration<DTOReclamacao>
    {
        public void Configure(EntityTypeBuilder<DTOReclamacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Destino).WithOne().HasForeignKey<DTOReclamacao>(x => x.DestinoId);
            builder.Property(x => x.Texto);
            builder.Property(x => x.DataCriacao);
            builder.HasOne(x => x.Autor).WithOne().HasForeignKey<DTOReclamacao>(x => x.AutorId);
            
        }
    }
}
