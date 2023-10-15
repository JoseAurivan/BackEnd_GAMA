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
    internal class ServidorConfiguration : IEntityTypeConfiguration<DTOServidor>
    {
        public void Configure(EntityTypeBuilder<DTOServidor> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasOne(x => x.User).WithOne().HasForeignKey<DTOServidor>(x => x.UserId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(x => x.Secretaria).WithMany(x => x.Servidores).HasForeignKey(x => x.SecretariaId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Property(x => x.Matricula);
            builder.HasOne(x => x.Cargo).WithMany(x => x.Servidors).HasForeignKey(x => x.CargoId).OnDelete(DeleteBehavior.ClientCascade);
            
        }
    }
}
