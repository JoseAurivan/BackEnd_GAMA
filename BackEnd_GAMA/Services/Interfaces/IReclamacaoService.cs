using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IReclamacaoService
    {
        Task DeleteReclamacaoAsync(Reclamacao reclamacao);
        Task SaveReclamacaoAsync(Reclamacao reclamacao);
        Task<Reclamacao> GetReclamacaoByIdAsync(int id);
        Task<IEnumerable<Reclamacao>> GetReclamacaosAsync();
    }
}
