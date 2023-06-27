using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataBaseModels.Entities
{
    public class DTOUser
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public DTOEndereco? Endereco { get; set; }

        public ICollection<DTOSolicitacao>? Solicitacao { get; set; }

        public int EnderecoId { get; set; }
        public string Email { get; set; }

        public string Telefone { get; set; }


        /// escreve o que aqui pra representar cidadao ou servidor?

    }
}