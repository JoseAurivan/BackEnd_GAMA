using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ISecretariaService
    {
        Task DeleteSecretariaAsync(Secretaria secretaria);
        Task SaveScretariaAsync(Secretaria secretaria);
        Task<Secretaria> GetSecretariaByIdAsync(int id);
        Task<IEnumerable<Secretaria>> GetSecretariaAsync();

    }
}
