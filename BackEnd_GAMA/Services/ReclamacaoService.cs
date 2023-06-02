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
    public class ReclamacaoService:IReclamacaoService
    {
        private readonly IReclamacaoRepository _reclamacaoRepository;

        public ReclamacaoService(IReclamacaoRepository reclamacaoRepository)
        {
            _reclamacaoRepository = reclamacaoRepository;
        }

        public async Task DeleteReclamacaoAsync(Reclamacao reclamacao) => await _reclamacaoRepository.DeleteReclamacaoAsync(reclamacao);
        public async Task SaveReclamacaoAsync(Reclamacao reclamacao) => await _reclamacaoRepository.SaveReclamacaoAsync(reclamacao);
        public async Task<Reclamacao> GetReclamacaoByIdAsync(int id)
        {
            return await _reclamacaoRepository.GetReclamacaoByIdAsync(id);
        }
        public async Task<IEnumerable<Reclamacao>> GetReclamacaosAsync()
        {
            return await _reclamacaoRepository.GetReclamacaos();
        }
    }
}
