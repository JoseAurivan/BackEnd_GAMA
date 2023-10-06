using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Entities.Abstract
{
    public class User
    {
        public User() {
        }

        public User(string nome, string cPF, string senha, Endereco? endereco, string email, string telefone)
        {
            Nome = nome;
            CPF = cPF;
            Senha = senha;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }

        public User(int id, string nome, string cPF, string senha, Endereco? endereco, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            Senha = senha;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }

        public int Id { get; set; }
        public string Nome { get;  set; }
        public string CPF { get;  set; }
        public string Senha { get; set; }
        public Endereco? Endereco { get;  set; }
        public string Email { get;  set; }

        public string Telefone { get;  set; }

    }
}