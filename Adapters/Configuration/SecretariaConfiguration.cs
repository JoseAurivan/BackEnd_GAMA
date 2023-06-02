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
    internal class SecretariaConfiguration : IEntityTypeConfiguration<Secretaria>
    {
        public void Configure(EntityTypeBuilder<Secretaria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Servidores).WithOne(x => x.Secretaria).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Solicitacoes).WithOne(x => x.SecretariaDestino).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Telefone);
            builder.Property(x => x.CNPJ);
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<Secretaria>(x => x.EnderecoId);
            builder.Property(x => x.Nome);
        }
    }
}
