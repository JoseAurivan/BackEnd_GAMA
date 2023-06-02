using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IServidorService
    {
        Task DeleteServidorAsync(Servidor servidor);
        Task SaveServidorAsync(Servidor servidor);
        Task<Servidor> GetServidorById(int id);
        Task<IEnumerable<Servidor>> GetServidors();
    }
}
