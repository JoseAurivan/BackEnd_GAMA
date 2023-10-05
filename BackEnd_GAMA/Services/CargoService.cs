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
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<Cargo> GetCargoByIdAsync(int id)
        {
            try
            {
                return await _cargoRepository.GetCargoByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SaveCargoAsync(Cargo cargo)
        {
            try { await _cargoRepository.SaveCargoAsync(cargo); }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteCargoAsync(Cargo cargo)
        {
            try { await _cargoRepository.DeleteCargoAsync(cargo); }
            catch(Exception ex) { throw; }
        }
        public async Task<IEnumerable<Cargo>> GetAllCargosAsync()
        {
            try { return await _cargoRepository.GetCargos(); }
            catch (Exception ex) { throw; }
        }
    }
}
