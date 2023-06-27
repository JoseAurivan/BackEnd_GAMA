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
    internal class CidadaoConfiguration : IEntityTypeConfiguration<DTOCidadao>
    {
        public void Configure(EntityTypeBuilder<DTOCidadao> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.PISPASEP);
            builder.HasOne(x => x.User).WithOne().HasForeignKey<DTOCidadao>(x => x.UserId);

        }
    }
}
