using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IChamadoService
    {
        Task DeleteChamadoAsync(Chamado chamado);
        Task SaveChamadoAsync(Chamado chamado);
        Task<Chamado> GetChamadoByIdAsync(int id);

        Task<IEnumerable<Chamado>> GetChamadosFromSecretaria(int secretariaId);
        Task<IEnumerable<Chamado>> GetChamadosAsync();
    }
}
