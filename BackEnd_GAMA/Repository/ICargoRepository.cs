using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> GetCargos();
        Task<Cargo> GetCargoByIdAsync(int id);
        Task SaveCargoAsync(Cargo Cargo);
        Task DeleteCargoAsync(Cargo Cargo);
    }
}
