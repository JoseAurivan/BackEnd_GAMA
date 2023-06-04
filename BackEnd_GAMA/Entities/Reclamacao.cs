namespace Core.Entities
{
    public class Reclamacao
    {
        public Reclamacao()
        {

        }

        public int Id { get;  set; }
        public int Autor { get;  set; }
        public string Texto { get;  set; }
        public DateTime DataCriacao { get;  set; }
        public int Destino { get;  set; }
    }
}