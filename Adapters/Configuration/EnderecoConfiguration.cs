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
    internal class EnderecoConfiguration : IEntityTypeConfiguration<DTOEndereco>
    {
        public void Configure(EntityTypeBuilder<DTOEndereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Rua);
            builder.Property(e => e.Bairro);
            builder.Property(e => e.Logradouro);
            builder.Property(e => e.CEP);
        }
    }
}
