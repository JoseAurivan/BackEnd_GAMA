using Core.Entities;
using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataBaseModels.Entities
{
    public class DTOUser
    {
        public DTOUser()
        {

        }
        public DTOUser(int id)
        {
            Id = id;    
        }

        public DTOUser(string nome, string cPF, string senha, DTOEndereco? endereco, string email, string telefone)
        {

            Nome = nome;
            CPF = cPF;
            Senha = senha;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }

        public DTOUser(string nome, string cPF, string senha, string email, string telefone)
        {

            Nome = nome;
            CPF = cPF;
            Senha = senha;
            Email = email;
            Telefone = telefone;
        }

        public DTOUser(int id, string nome, string cPF, string senha, DTOEndereco? endereco, string email, string telefone)
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
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public DTOEndereco? Endereco { get; set; }

        public ICollection<DTOSolicitacao>? Solicitacao { get; set; }

        public int? EnderecoId { get; set; }
        public string Email { get; set; }

        public string Telefone { get; set; }

        public Cidadao ConverterParaModel(DTOUser user)
        {
            return new Cidadao(user.CPF, user.Id, user.Nome, user.Email, user.Telefone);
        }

        /// escreve o que aqui pra representar cidadao ou servidor?

    }
}