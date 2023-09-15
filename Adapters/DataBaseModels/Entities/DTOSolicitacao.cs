using Core.Entities;
using Core.Entities.Abstract;

namespace Infrastructure.DataBaseModels.Entities
{
    public class DTOSolicitacao
    {
        public DTOSolicitacao(int id, string descricao, string numeroProtocolo, StatusSolicitacao statusSolicitacao, DTOSecretaria? secretariaDestino, DTOUser? solicitadoPor, DTOServidor? atendidoPor, DateTime inicio, DateTime fim)
        {
            Id = id;
            Descricao = descricao;
            NumeroProtocolo = numeroProtocolo;
            StatusSolicitacao = statusSolicitacao;
            SecretariaDestino = secretariaDestino;
            SolicitadoPor = solicitadoPor;
            AtendidoPor = atendidoPor;
            Inicio = inicio;
            Fim = fim;
        }

        public DTOSolicitacao( string descricao, string numeroProtocolo, StatusSolicitacao statusSolicitacao, DTOSecretaria? secretariaDestino, DTOUser? solicitadoPor, DTOServidor? atendidoPor, DateTime inicio, DateTime fim)
        {
            Descricao = descricao;
            NumeroProtocolo = numeroProtocolo;
            StatusSolicitacao = statusSolicitacao;
            SecretariaDestino = secretariaDestino;
            SolicitadoPor = solicitadoPor;
            AtendidoPor = atendidoPor;
            Inicio = inicio;
            Fim = fim;
        }


        public DTOSolicitacao()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string NumeroProtocolo { get; set; }
        public StatusSolicitacao StatusSolicitacao { get; set; }
        public DTOSecretaria? SecretariaDestino { get; set; }
        public int SecretariaId { get; set; }
        public DTOUser? SolicitadoPor { get; set; }
        public int SolicitadoPorId { get; set; }
        public DTOServidor? AtendidoPor { get; set; }
        public int AtendidoPorId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public Solicitacao ConverterDTOParaModel()
        {
            return new Solicitacao();
        }

    }

}