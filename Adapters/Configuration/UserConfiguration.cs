using Infrastructure.DataBaseModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<DTOUser>
    {
        public void Configure(EntityTypeBuilder<DTOUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Email);
            builder.Property(x => x.Senha);
            builder.Property(x => x.Telefone);
            builder.Property(x => x.CPF);
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<DTOUser>(x => x.EnderecoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
