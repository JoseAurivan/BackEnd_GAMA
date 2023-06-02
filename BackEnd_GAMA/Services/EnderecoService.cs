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
    public class EnderecoService:IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task DeleteEnderecoAsync(Endereco endereco) => await _enderecoRepository.DeleteEnderecoAsync(endereco);
        public async Task SaveEnderecoAsync(Endereco endereco) => await _enderecoRepository.SaveEnderecoAsync(endereco);
        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            return await _enderecoRepository.GetEnderecoByIdAsync(id);
        }
        public async Task<IEnumerable<Endereco>>GetEnderecosAsync()
        {
            return await _enderecoRepository.GetEnderecos();
        }
    }
}
