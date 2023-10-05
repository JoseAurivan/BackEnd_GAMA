using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IServidorRepository
    {
        Task<IEnumerable<Servidor>> GetServidors();
        Task<Servidor> AuthenticateServidor(string matricula, string password);
        Task<Servidor> GetServidorByIdAsync(int id);
        Task<Servidor> GetServidorByMatriculaAsync(string matricula);
        Task SaveServidorAsync(Servidor Servidor);
        Task DeleteServidorAsync(Servidor Servidor);
    }
}
