using Core.Entities.Abstract;

namespace Core.Entities
{
    public class Secretaria
    {

        public int Id { get;  set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string? CNPJ { get; private set; }
        public ICollection<Servidor> Servidores { get; private set; }

        public ICollection<Solicitacao> Solicitacoes { get; private set; }
        public Endereco Endereco { get; private set; }
        public int EnderecoId { get; private set; }

        public Secretaria()
        {
            Servidores = new List<Servidor>();
        }

    }
}