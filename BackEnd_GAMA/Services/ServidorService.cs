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
    public class ServidorService:IServidorService
    {
        private readonly IServidorRepository _servidorRepository;

        public ServidorService(IServidorRepository servidorRepository)
        {
            _servidorRepository = servidorRepository;
        }

        public async Task DeleteServidorAsync(Servidor servidor) => await _servidorRepository.DeleteServidorAsync(servidor);
        public async Task SaveServidorAsync(Servidor servidor) => await _servidorRepository.SaveServidorAsync(servidor);
        public async Task<Servidor> GetServidorById(int id)
        {
            return await _servidorRepository.GetServidorByIdAsync(id);
        }
        public async Task<IEnumerable<Servidor>> GetServidors()
        {
            return await _servidorRepository.GetServidors();
        }
    }
}
