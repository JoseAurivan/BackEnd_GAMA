using Core.Entities.Abstract;

namespace Core.Entities
{
    public class Secretaria
    {

        public int Id { get; set; }
        public string Nome { get;  set; }
        public string Telefone { get;  set; }
        public string? CNPJ { get;  set; }
        public ICollection<Servidor>? Servidores { get;  set; }

        public ICollection<Solicitacao>? Solicitacoes { get;  set; }
        public Endereco? Endereco { get;  set; }
        public int? EnderecoId { get;  set; }

        public Secretaria()
        {
            Servidores = new List<Servidor>();
            Solicitacoes = new List<Solicitacao>();
        }

        public Secretaria(int id, string nome, string telefone, string? cNPJ)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CNPJ = cNPJ;
        }

        public Secretaria(int id, string nome, string telefone, string? cNPJ, ICollection<Servidor>? servidores, ICollection<Solicitacao>? solicitacoes, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CNPJ = cNPJ;
            Servidores = servidores;
            Solicitacoes = solicitacoes;
            Endereco = endereco;
        }
    }
}