using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Abstract
{
    public abstract class User
    {

        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string CPF { get;  set; }
        public string Senha { get; set; }
        public Endereco? Endereco { get;  set; }
        public string Email { get;  set; }

        public string Telefone { get;  set; }

    }
}