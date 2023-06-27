namespace Core.Entities
{
    public class DTOReclamacao
    {
        public DTOReclamacao()
        {

        }

        public int Id { get;  set; }
        public DTOCidadao? Autor { get;  set; }
        public int AutorId { get; set; }
        public string Texto { get;  set; }
        public DateTime DataCriacao { get;  set; }
        public DTOSecretaria? Destino { get;  set; }
        public int DestinoId { get; set; }
    }
}