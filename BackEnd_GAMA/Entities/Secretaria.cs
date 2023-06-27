using Core.Entities.Abstract;

namespace Core.Entities
{
    public class Secretaria
    {

        public string Nome { get;  set; }
        public string Telefone { get;  set; }
        public string? CNPJ { get;  set; }
        public ICollection<Servidor> Servidores { get;  set; }

        public ICollection<Solicitacao> Solicitacoes { get;  set; }
        public Endereco Endereco { get;  set; }
        public int EnderecoId { get;  set; }

        public Secretaria()
        {
            Servidores = new List<Servidor>();
        }

    }
}