namespace Core.Entities.Abstract
{
    public abstract class Solicitacao
    {
        public int Id { get; set; }
        public string Descricao { get;  set; }
        public string NumeroProtocolo { get;  set; }
        public StatusSolicitacao StatusSolicitacao { get;  set; }
        public Secretaria SecretariaDestino { get;  set; }
        public User SolicitadoPor { get;  set; }
        public Servidor AtendidoPor { get;  set; }
        public DateTime Inicio { get;  set; }
        public DateTime Fim { get;  set; }

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