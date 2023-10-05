namespace Core.Entities
{
    public class Reclamacao
    {
        public Reclamacao()
        {

        }

        public Reclamacao(Cidadao autor, string texto, DateTimeOffset dataCriacao, Secretaria destino)
        {
            Autor = autor;
            Texto = texto;
            DataCriacao = dataCriacao;
            Destino = destino;
        }

        public Reclamacao(int id, Cidadao autor, string texto, DateTimeOffset dataCriacao, Secretaria destino)
        {
            Id = id;
            Autor = autor;
            Texto = texto;
            DataCriacao = dataCriacao;
            Destino = destino;
        }

        public int Id { get; set; }
        public Cidadao Autor { get;  set; }
        public string Texto { get;  set; }
        public DateTimeOffset DataCriacao { get;  set; }
        public Secretaria Destino { get;  set; }
    }
}