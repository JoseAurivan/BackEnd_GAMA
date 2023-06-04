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
    internal class CidadaoConfiguration : IEntityTypeConfiguration<Cidadao>
    {
        public void Configure(EntityTypeBuilder<Cidadao> builder)
        {
            builder.Property(x => x.Nome);
            builder.Property(x => x.CPF).IsRequired(true);
            builder.Property(x => x.Senha);
            builder.Property(x => x.PISPASEP);
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<Cidadao>(x => x.EnderecoId).IsRequired(false);
            builder.Property(x => x.Telefone);
            builder.Property(x => x.Email);
        }
    }
}
