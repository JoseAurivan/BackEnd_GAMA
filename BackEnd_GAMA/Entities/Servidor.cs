using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Servidor : User
    {

        public Servidor()
        {

        }
        public Servidor(string nome,string cpf, string matricula, Secretaria secretaria, Cargo cargo)
        {
            Nome = nome;
            CPF = cpf;
            Secretaria = secretaria;
            Cargo = cargo;
        }

        public Servidor(string nome, string cpf, string matricula, Cargo cargo)
        {
            Nome = nome;
            CPF = cpf;
            Cargo = cargo;
        }

        public Servidor(string matricula)
        {
            Matricula = matricula;
        }
        public Servidor(string matricula,Cargo cargo)
        {
            Matricula = matricula;
            Cargo = cargo;
        }

        public Servidor(string nome, string cpf, string matricula, string senha, string telefone, string email, Secretaria secretaria, Cargo cargo)
        {
            Nome = nome;
            CPF = cpf;
            Matricula = matricula;
            Secretaria = secretaria;
            Cargo = cargo;
            Senha = senha;
            Telefone = telefone;
            Email = email;
        }

        public Servidor(int id,string nome, string cpf, string matricula, string senha, string telefone, string email, Secretaria secretaria, Cargo cargo)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Matricula = matricula;
            Secretaria = secretaria;
            Cargo = cargo;
            Senha = senha;
            Telefone = telefone;
            Email = email;
        }

        public Servidor(int id, string nome, string cpf, string matricula, string senha, string telefone, string email, Cargo cargo)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Matricula = matricula;
            Cargo = cargo;
            Senha = senha;
            Telefone = telefone;
            Email = email;
        }


        public string Matricula { get;  set; }
        public Secretaria Secretaria { get; private set; }
        public Cargo Cargo { get; private set; }



    }
}
