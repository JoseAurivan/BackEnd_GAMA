using Core.Entities;
using Core.Entities.Abstract;

namespace Infrastructure.DataBaseModels.Entities
{
    public class DTOSolicitacao
    {
        public DTOSolicitacao(int id, string descricao, string numeroProtocolo, StatusSolicitacao statusSolicitacao, DTOSecretaria? secretariaDestino, DTOUser? solicitadoPor, DTOServidor? atendidoPor, DateTimeOffset inicio, DateTimeOffset fim)
        {
            Id = id;
            Descricao = descricao;
            NumeroProtocolo = numeroProtocolo;
            StatusSolicitacao = statusSolicitacao;
            SecretariaDestino = secretariaDestino;
            SolicitadoPor = solicitadoPor;
            AtendidoPor = atendidoPor;
            Inicio = DateTime.SpecifyKind(inicio.DateTime, DateTimeKind.Utc); 
            Fim = DateTime.SpecifyKind(fim.DateTime, DateTimeKind.Utc); 
        }

        public DTOSolicitacao( string descricao, string numeroProtocolo, StatusSolicitacao statusSolicitacao, DTOSecretaria? secretariaDestino, DTOUser? solicitadoPor, DTOServidor? atendidoPor, DateTimeOffset inicio, DateTimeOffset fim)
        {
            Descricao = descricao;
            NumeroProtocolo = numeroProtocolo;
            StatusSolicitacao = statusSolicitacao;
            SecretariaDestino = secretariaDestino;
            SolicitadoPor = solicitadoPor;
            AtendidoPor = atendidoPor;
            Inicio = DateTime.SpecifyKind(inicio.DateTime, DateTimeKind.Utc);
            Fim = DateTime.SpecifyKind(fim.DateTime, DateTimeKind.Utc);
        }

        public DTOSolicitacao(string descricao, string numeroProtocolo, StatusSolicitacao statusSolicitacao, int secretariaDestino, int solicitadoPor, DateTimeOffset inicio)
        {
            Descricao = descricao;
            NumeroProtocolo = numeroProtocolo;
            StatusSolicitacao = statusSolicitacao;
            SecretariaId = secretariaDestino;
            SolicitadoPorId = solicitadoPor;
            Inicio = DateTime.SpecifyKind( inicio.DateTime,DateTimeKind.Utc);
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
        public int? AtendidoPorId { get; set; }
        public DateTimeOffset Inicio { get; set; }
        public DateTimeOffset? Fim { get; set; }

        public Solicitacao ConverterDTOParaModel()
        {
            return new Solicitacao();
        }

    }

}