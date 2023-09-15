namespace Core.Entities
{
    public class Reclamacao
    {
        public Reclamacao()
        {

        }

        public Reclamacao(int id, Cidadao autor, string texto, DateTime dataCriacao, Secretaria destino)
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
        public DateTime DataCriacao { get;  set; }
        public Secretaria Destino { get;  set; }
    }
}