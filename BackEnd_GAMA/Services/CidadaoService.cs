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
           return await _cidadaoRepository.GetCidadaoByIdAsync(id);
        }
        public async Task DeleteCidadaoAsync(Cidadao cidadao)
        {
            await _cidadaoRepository.DeleteCidadaoAsync(cidadao);
        }
        public async Task SaveCidadaoAsync(Cidadao cidadao)
        {
            await _cidadaoRepository.SaveCidadaoAsync(cidadao);
        }
        public async Task<IEnumerable<Cidadao>> GetAllCidadao()
        {
            return await _cidadaoRepository.GetCidadaos();
        }
    }
}