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
    public class ReclamacaoService : IReclamacaoService
    {
        private readonly IReclamacaoRepository _reclamacaoRepository;

        public ReclamacaoService(IReclamacaoRepository reclamacaoRepository)
        {
            _reclamacaoRepository = reclamacaoRepository;
        }

        public async Task DeleteReclamacaoAsync(Reclamacao reclamacao)
        {
            try
            {
                await _reclamacaoRepository.DeleteReclamacaoAsync(reclamacao);
            }
            catch (Exception ex) { throw; }
        }
        public async Task SaveReclamacaoAsync(Reclamacao reclamacao)
        {
            try { await _reclamacaoRepository.SaveReclamacaoAsync(reclamacao); }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Reclamacao> GetReclamacaoByIdAsync(int id)
        {
            try { return await _reclamacaoRepository.GetReclamacaoByIdAsync(id); }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Reclamacao>> GetReclamacaosAsync()
        {
            try { return await _reclamacaoRepository.GetReclamacaos(); }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
