using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{

    public interface ICestaBasicaService
    {
        Task DeleteCestaBasicaAsync(CestaBasica cestaBasica);
        Task SaveCestaBasicaAsync(CestaBasica cestaBasica);
        Task<CestaBasica> getCestaBasicaByIdAsync(int id);
        Task<IEnumerable<CestaBasica>> GetCestaBasicasAsync();

    }
}
