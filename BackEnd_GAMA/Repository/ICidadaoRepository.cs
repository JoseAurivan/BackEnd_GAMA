using Core.Entities;
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
        Task<Cidadao>? GetCidadaoByIdAsync(int id);
        Task<IEnumerable<Cidadao>> GetCidadaos();
        Task SaveCidadaoAsync(Cidadao cidadao);
    }
}
