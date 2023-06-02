using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICargoService
    {
        Task<Cargo> GetCargoByIdAsync(int id);
        Task SaveCargoAsync(Cargo cargo);
        Task DeleteCargoAsync(Cargo cargo);
        Task<IEnumerable<Cargo>> GetAllCargosAsync();
    }
}
