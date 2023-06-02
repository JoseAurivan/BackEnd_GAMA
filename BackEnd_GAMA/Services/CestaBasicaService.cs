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
    public class CestaBasicaService:ICestaBasicaService
    {
        private readonly ICestaBasicaRepository _cestaBasicaRepository;

        public CestaBasicaService(ICestaBasicaRepository cestaBasicaRepository)
        {
            _cestaBasicaRepository = cestaBasicaRepository;
        }

        public async Task DeleteCestaBasicaAsync(CestaBasica cestaBasica)=> await _cestaBasicaRepository.DeleteCestaBasicaAsync(cestaBasica);
        
        public async Task SaveCestaBasicaAsync(CestaBasica cestaBasica) => await _cestaBasicaRepository.SaveCestaBasicaoAsync(cestaBasica);
        public async Task<CestaBasica> getCestaBasicaByIdAsync(int id)
        {
            return await _cestaBasicaRepository.GetCestaBasicaByIdAsync(id);
        }
        public async Task<IEnumerable<CestaBasica>> GetCestaBasicasAsync()
        {
            return await _cestaBasicaRepository.GetCestaBasicas();
        }
    }

}
