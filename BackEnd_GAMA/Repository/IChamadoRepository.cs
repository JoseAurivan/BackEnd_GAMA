using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IChamadoRepository
    {
        Task<IEnumerable<Chamado>> GetChamados();
        Task<Chamado> GetChamadoByIdAsync(int id);
        Task SaveChamadooAsync(Chamado Chamado);
        Task DeleteChamadoAsync(Chamado Chamado);
    }
}
