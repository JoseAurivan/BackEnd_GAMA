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
    internal class ServidorConfiguration : IEntityTypeConfiguration<Servidor>
    {
        public void Configure(EntityTypeBuilder<Servidor> builder)
        {
            builder.Property(x => x.Nome);
            builder.Property(x => x.CPF).IsRequired();
            builder.Property(x => x.Senha);
            builder.HasOne(x => x.Endereco);
            builder.Property(x => x.Telefone);
            builder.Property(x => x.Email);
            builder.Property(x => x.Matricula);
            builder.HasOne(x => x.Cargo).WithOne().HasForeignKey<Servidor>(x => x.CargoId);
            
        }
    }
}
