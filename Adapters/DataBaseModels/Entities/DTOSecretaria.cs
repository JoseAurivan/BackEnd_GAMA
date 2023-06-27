using Infrastructure.DataBaseModels.Entities;

namespace Core.Entities
{
    public class DTOSecretaria
    {

        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Telefone { get;  set; }
        public string? CNPJ { get;  set; }
        public ICollection<DTOServidor>? Servidores { get;  set; }

        public ICollection<DTOSolicitacao>? Solicitacoes { get;  set; }
        public DTOEndereco? Endereco { get;  set; }
        public int EnderecoId { get;  set; }

        public DTOSecretaria()
        {
            Servidores = new List<DTOServidor>();
            Solicitacoes = new List<DTOSolicitacao>();
        }

    }
}