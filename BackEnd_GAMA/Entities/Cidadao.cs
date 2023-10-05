using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cidadao : User
    {
        public string PISPASEP { get;  set; }
        public Cidadao()
        {
            
        }

        public Reclamacao RealizarReclamacao(string reclamacao, Secretaria secretaria)
        {
            return null;
        }

        public Cidadao(string pispasep, string cpf, int id, string nome, string email, string telefone)
        {
            PISPASEP= pispasep;
            CPF= cpf;
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Cidadao(string pispasep, string cpf, int id, string nome, string email, string telefone, string senha)
        {
            PISPASEP = pispasep;
            CPF = cpf;
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Senha = senha;
        }

        public Cidadao( string cpf, int id, string nome, string email, string telefone)
        {
            CPF = cpf;
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

    }
}
