using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface ISecretariaRepository
    {
        Task<IEnumerable<Secretaria>> GetSecretarias();
        Task<Secretaria> GetSecretariaByIdAsync(int id);
        Task SaveSecretariaAsync(Secretaria Secretaria);
        Task DeleteSecretariaAsync(Secretaria Secretaria);
    }
}
