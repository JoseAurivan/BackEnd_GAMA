using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> GetEnderecos();
        Task<Endereco> GetEnderecoByIdAsync(int id);
        Task SaveEnderecoAsync(Endereco Endereco);
        Task DeleteEnderecoAsync(Endereco Endereco);

    }
}
