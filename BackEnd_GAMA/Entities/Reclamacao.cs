namespace Core.Entities
{
    public class Reclamacao
    {
        public Reclamacao()
        {

        }

        public Cidadao Autor { get;  set; }
        public string Texto { get;  set; }
        public DateTime DataCriacao { get;  set; }
        public Secretaria Destino { get;  set; }
    }
}