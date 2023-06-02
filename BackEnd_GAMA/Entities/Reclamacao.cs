namespace Core.Entities
{
    public class Reclamacao
    {
        public Reclamacao()
        {

        }

        public int Id { get;  set; }
        public int Autor { get; private set; }
        public string Texto { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public int Destino { get; private set; }
    }
}