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
    public class FamiliaService:IFamiliaService
    {
        private readonly IFamiliaRepository _familiaRepository;

        public FamiliaService(IFamiliaRepository familiaRepository)
        {
            _familiaRepository = familiaRepository;
        }
        public async Task DeleteFamiliaAsync(Familia familia) => await _familiaRepository.DeleteFamiliaAsync(familia);
        public async Task SaveFamiliaAsync(Familia familia) => await _familiaRepository.SaveFamiliaAsync(familia);
        public async Task<Familia> GetFamiliaByIdAsync(int id)
        {
            return await _familiaRepository.GetFamiliaByIdAsync(id);
        }
        public async Task<IEnumerable<Familia>> GetFamiliaAsync()
        {
            return await _familiaRepository.GetFamilias();
        }
    }
}
