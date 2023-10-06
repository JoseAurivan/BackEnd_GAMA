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
    public class ServidorService : IServidorService
    {
        private readonly IServidorRepository _servidorRepository;

        public ServidorService(IServidorRepository servidorRepository)
        {
            _servidorRepository = servidorRepository;
        }

        public async Task DeleteServidorAsync(Servidor servidor)
        {
            try
            {
                await _servidorRepository.DeleteServidorAsync(servidor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task SaveServidorAsync(Servidor servidor)
        {
            try { await _servidorRepository.SaveServidorAsync(servidor); } catch (Exception) { throw; }
        }
        public async Task<Servidor> GetServidorById(int id)
        {
            try { return await _servidorRepository.GetServidorByIdAsync(id); }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Servidor>> GetServidors()
        {
            try { return await _servidorRepository.GetServidors(); }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Servidor> GetServidorByMatriucla(string matricula)
        {
            try
            {
                return await _servidorRepository.GetServidorByMatriculaAsync(matricula);
            }catch(Exception)
            {
                throw;
            }
        }
    }
}
