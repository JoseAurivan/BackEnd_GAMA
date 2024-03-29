﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface ICidadaoRepository
    {
        Task DeleteCidadaoAsync(Cidadao cidadao);
        Task<Cidadao> AuthenticateCidadao(string cpf, string password);
        Task<Cidadao>? GetCidadaoByIdAsync(int id);
        Task<Cidadao> GetCidadaoByCPFAsync(string cpf);
        Task<IEnumerable<Cidadao>> GetCidadaos();
        Task<int> SaveCidadaoAsync(Cidadao cidadao);
    }
}
