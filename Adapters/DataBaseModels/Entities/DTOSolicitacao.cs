using Core.Entities;
using Core.Entities.Abstract;

namespace Infrastructure.DataBaseModels.Entities
{
    public class DTOSolicitacao
    {
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

    }

}