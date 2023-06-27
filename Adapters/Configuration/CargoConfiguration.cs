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
    internal class CargoConfiguration : IEntityTypeConfiguration<DTOCargo>
    {
        public void Configure(EntityTypeBuilder<DTOCargo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Salario);
            builder.Property(x => x.Hierarquia);
        }
    }
}
