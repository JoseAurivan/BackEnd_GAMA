using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IFamiliaRepository
    {
        Task<IEnumerable<Familia>> GetFamilias();
        Task<Familia> GetFamiliaByIdAsync(int id);
        Task SaveFamiliaAsync(Familia Familia);
        Task DeleteFamiliaAsync(Familia Familia);
    }
}
