namespace Core.Entities.Abstract
{
    public  class Solicitacao
    {
        public Solicitacao()
        {

        }

        public Solicitacao(string descricao, string numeroProtocolo, StatusSolicitacao statusSolicitacao, Secretaria secretariaDestino, User solicitadoPor, Servidor? atendidoPor, DateTimeOffset inicio, DateTimeOffset fim)
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

        public Solicitacao(int id, string descricao, string numeroProtocolo, StatusSolicitacao statusSolicitacao, Secretaria secretariaDestino, User solicitadoPor, Servidor? atendidoPor, DateTimeOffset inicio, DateTimeOffset fim)
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

        public int Id { get; set; }
        public string Descricao { get;  set; }
        public string NumeroProtocolo { get;  set; }
        public StatusSolicitacao StatusSolicitacao { get;  set; }
        public Secretaria SecretariaDestino { get;  set; }
        public User SolicitadoPor { get;  set; }
        public Servidor? AtendidoPor { get;  set; }
        public DateTimeOffset Inicio { get;  set; }
        public DateTimeOffset Fim { get;  set; }

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