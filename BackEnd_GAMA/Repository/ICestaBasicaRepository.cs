using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface ICestaBasicaRepository
    {
        Task DeleteCestaBasicaAsync(CestaBasica CestaBasica);
        Task<CestaBasica> GetCestaBasicaByIdAsync(int id);
        Task<IEnumerable<CestaBasica>> GetCestaBasicas();
        Task SaveCestaBasicaoAsync(CestaBasica CestaBasica);
    }
}
