using Core.Entities;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public class LoginService : ILoginService
    {
        private ICidadaoRepository _cidadaoRepository;
        private IServidorRepository _servidorRepository;

        public LoginService(ICidadaoRepository cidadaoRepository, IServidorRepository servidorRepository)
        {
            _cidadaoRepository = cidadaoRepository;
            _servidorRepository = servidorRepository;
        }

        public async Task<Cidadao> AuthenticateCidadao(string cpf, string password)
        {
            return await _cidadaoRepository.AuthenticateCidadao(cpf, password);
        }

        public async Task<Servidor> AuthenticateServidor(string matricula, string password)
        {
            return await _servidorRepository.AuthenticateServidor(matricula, password);
        }
    }
}
