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
    public class SecretariaService:ISecretariaService
    {
        private readonly ISecretariaRepository _secretariaRepository;

        public SecretariaService(ISecretariaRepository secretariaRepository)
        {
            _secretariaRepository = secretariaRepository;
        }

        public async Task DeleteSecretariaAsync(Secretaria secretaria) => await _secretariaRepository.DeleteSecretariaAsync(secretaria);
        public async Task SaveScretariaAsync(Secretaria secretaria)=> await _secretariaRepository.SaveSecretariaAsync(secretaria);
        public async Task<Secretaria> GetSecretariaByIdAsync(int id)
        {
            return await _secretariaRepository.GetSecretariaByIdAsync(id);
        }
        public async Task<IEnumerable<Secretaria>> GetSecretariaAsync()
        {
            return await _secretariaRepository.GetSecretarias();
        }
    }
}
