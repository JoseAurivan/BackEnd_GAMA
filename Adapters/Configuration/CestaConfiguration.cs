﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class CestaConfiguration : IEntityTypeConfiguration<DTOCestaBasica>
    {
        public void Configure(EntityTypeBuilder<DTOCestaBasica> builder)
        {
            builder.HasKey(x => x.SolcitacaoID);
            builder.HasOne(x => x.Solicitacao).WithOne().HasForeignKey<DTOCestaBasica>(x => x.SolcitacaoID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<DTOCestaBasica>(x => x.EnderecoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Familia).WithMany(x => x.Cestas).HasForeignKey(x => x.FamiliaId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
