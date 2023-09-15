using Core.Entities.Abstract;
using Infrastructure.DataBaseModels.Entities;

namespace Core.Entities
{
    public class DTOSecretaria
    {
        public DTOSecretaria(int id)
        {
            Id = id;
        }

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

        public DTOSecretaria(int id, string nome, string telefone, string? cNPJ, int enderecoId)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CNPJ = cNPJ;
            EnderecoId = enderecoId;
        }

        public DTOSecretaria( string nome, string telefone, string? cNPJ, int enderecoId)
        {
            Nome = nome;
            Telefone = telefone;
            CNPJ = cNPJ;
            EnderecoId = enderecoId;
        }

        public Secretaria ConverterDTOParaModel(DTOSecretaria secretaria,List<Solicitacao> solicitacaos,List<Servidor>servidors,Endereco endereco)
        {
            return new Secretaria(secretaria.Id,secretaria.Nome,secretaria.Telefone,secretaria.CNPJ,servidors,solicitacaos,endereco);
        }

        public Secretaria ConverterDTOParaModel(DTOSecretaria secretaria)
        {
            return new Secretaria(secretaria.Id,secretaria.Nome,secretaria.Telefone,secretaria.CNPJ);
        }

    }
}