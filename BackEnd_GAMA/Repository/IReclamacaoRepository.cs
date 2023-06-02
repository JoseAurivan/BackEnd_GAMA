using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IReclamacaoRepository
    {
        Task<IEnumerable<Reclamacao>> GetReclamacaos();
        Task<Reclamacao> GetReclamacaoByIdAsync(int id);
        Task SaveReclamacaoAsync(Reclamacao Reclamacao);
        Task DeleteReclamacaoAsync(Reclamacao Reclamacao);
    }
}
