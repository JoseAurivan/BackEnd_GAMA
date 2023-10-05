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
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {

            _enderecoRepository = enderecoRepository;
        }

        public async Task DeleteEnderecoAsync(Endereco endereco)
        {
            try
            {
                await _enderecoRepository.DeleteEnderecoAsync(endereco);
            }
            catch (Exception ex) { throw; }
        }
        public async Task<int> SaveEnderecoAsync(Endereco endereco)
        {
            try { return await _enderecoRepository.SaveEnderecoAsync(endereco); }
            catch (Exception ex) { throw; }
        }
        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            try { return await _enderecoRepository.GetEnderecoByIdAsync(id); }
            catch(Exception ex) { throw; }
        }
        public async Task<IEnumerable<Endereco>> GetEnderecosAsync()
        {
            try { return await _enderecoRepository.GetEnderecos(); }
            catch(Exception ex) { throw; }
        }
    }
}
