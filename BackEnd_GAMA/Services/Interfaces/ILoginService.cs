using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ILoginService
    {
        Task<Cidadao> AuthenticateCidadao(string cpf, string password);
        Task<Servidor> AuthenticateServidor(string matricula, string password);
    }
}
