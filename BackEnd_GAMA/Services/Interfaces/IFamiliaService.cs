using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IFamiliaService
    {
        Task DeleteFamiliaAsync(Familia familia);
        Task SaveFamiliaAsync(Familia familia);
        Task<Familia> GetFamiliaByIdAsync(int id);
        Task<IEnumerable<Familia>> GetFamiliaAsync();
    }
}
