using Core.Entities;
using Core.Repository;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CargoService:ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<Cargo> GetCargoByIdAsync(int id)
        {
            return await _cargoRepository.GetCargoByIdAsync(id);
        }

        public async Task SaveCargoAsync(Cargo cargo)
        {
            await _cargoRepository.SaveCargoAsync(cargo);
        }
        public async Task DeleteCargoAsync(Cargo cargo)
        {
            await _cargoRepository.DeleteCargoAsync(cargo);
        }
        public async Task<IEnumerable<Cargo>> GetAllCargosAsync()
        {
           return await _cargoRepository.GetCargos();
        }
    }
}
