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
    internal class FamiliaConfiguration : IEntityTypeConfiguration<DTOFamilia>
    {
        public void Configure(EntityTypeBuilder<DTOFamilia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Membros).WithOne(x => x.Familia);
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<DTOFamilia>(x => x.EnderecoId);
            builder.HasMany(x => x.Cestas).WithOne(x => x.Familia).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
