using Core.Entities;
using Core.Repository;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class SecretariaService : ISecretariaService
    {
        private readonly ISecretariaRepository _secretariaRepository;

        public SecretariaService(ISecretariaRepository secretariaRepository)
        {
            _secretariaRepository = secretariaRepository;
        }

        public async Task DeleteSecretariaAsync(Secretaria secretaria)
        {
            try
            {
                await _secretariaRepository.DeleteSecretariaAsync(secretaria);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task SaveScretariaAsync(Secretaria secretaria)
        {
            try
            {
                await _secretariaRepository.SaveSecretariaAsync(secretaria);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Secretaria> GetSecretariaByIdAsync(int id)
        {
            try
            {
                return await _secretariaRepository.GetSecretariaByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Secretaria>> GetSecretariaAsync()
        {
            try { return await _secretariaRepository.GetSecretarias(); }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
