using Core.Entities;
using Core.Repository;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class CidadaoService : ICidadaoService
    {
        private readonly ICidadaoRepository _cidadaoRepository;

        public CidadaoService(ICidadaoRepository cidadaoRepository)
        {
            _cidadaoRepository = cidadaoRepository;
        }

        public async Task<Cidadao> GetCidadaoById(int id)
        {
            try
            {
                return await _cidadaoRepository.GetCidadaoByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Cidadao> GetCidadaoByCPFAsync(string cpf)
        {
            try
            {
                return await _cidadaoRepository.GetCidadaoByCPFAsync(cpf);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteCidadaoAsync(Cidadao cidadao)
        {
            try
            {
                await _cidadaoRepository.DeleteCidadaoAsync(cidadao);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> SaveCidadaoAsync(Cidadao cidadao)
        {
            try
            {
                return await _cidadaoRepository.SaveCidadaoAsync(cidadao);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Cidadao>> GetAllCidadao()
        {
            try
            {
                return await _cidadaoRepository.GetCidadaos();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}