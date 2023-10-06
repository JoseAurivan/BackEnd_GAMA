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
    internal class SecretariaConfiguration : IEntityTypeConfiguration<DTOSecretaria>
    {
        public void Configure(EntityTypeBuilder<DTOSecretaria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Telefone);
            builder.Property(x => x.CNPJ);
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<DTOSecretaria>(x => x.EnderecoId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Nome);
        }
    }
}
