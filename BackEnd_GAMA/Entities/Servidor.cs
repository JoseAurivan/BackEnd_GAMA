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

        public int Id { get; set; }
        public string Matricula { get;  set; }
        public Secretaria Secretaria { get; private set; }
        public Cargo Cargo { get; private set; }



    }
}
