using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Abstract
{
    public abstract class User
    {

        public int Id { get;  set; }
        public string Nome { get; protected set; }
        public string CPF { get; protected set; }
        public Endereco Endereco { get; protected set; }
        public string Email { get; protected set; }

        public string Telefone { get; protected set; }

    }
}