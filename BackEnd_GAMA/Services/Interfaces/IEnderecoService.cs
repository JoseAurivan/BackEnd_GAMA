using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task DeleteEnderecoAsync(Endereco endereco);
        Task SaveEnderecoAsync(Endereco endereco);
        Task<Endereco> GetEnderecoByIdAsync(int id);
        Task<IEnumerable<Endereco>> GetEnderecosAsync();
    }
}
