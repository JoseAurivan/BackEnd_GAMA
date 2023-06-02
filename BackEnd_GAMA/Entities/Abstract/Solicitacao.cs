namespace Core.Entities.Abstract
{
    public abstract class Solicitacao
    {
        public int Id { get; set; }
        public string Descricao { get; protected set; }
        public string NumeroProtocolo { get; protected set; }
        public StatusSolicitacao StatusSolicitacao { get; protected set; }
        public Secretaria SecretariaDestino { get; protected set; }
        public User SolicitadoPor { get; protected set; }
        public Servidor AtendidoPor { get; protected set; }
        public DateTime Inicio { get; protected set; }
        public DateTime Fim { get; protected set; }

    }

    public enum StatusSolicitacao
    {
        Aprovada,
        Negada,
        EmAnalise,
        Aberta,
        Entregue
    }
}