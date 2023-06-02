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
    internal class ReclamacaoConfiguration : IEntityTypeConfiguration<Reclamacao>
    {
        public void Configure(EntityTypeBuilder<Reclamacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Destino);
            builder.Property(x => x.Texto);
            builder.Property(x => x.DataCriacao);
            builder.Property(x => x.Autor);
            
        }
    }
}
