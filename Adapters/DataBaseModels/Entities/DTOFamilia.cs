namespace Core.Entities
{
    public class DTOFamilia
    {
        public DTOFamilia()
        {
            Membros = new List<DTOCidadao>();
            Cestas = new List<DTOCestaBasica>();
        }

        public int Id { get;  set; }
        public ICollection<DTOCidadao> Membros { get;  set; }
        public ICollection<DTOCestaBasica> Cestas { get;  set; }
        public DTOEndereco Endereco { get; private set; }
        public int EnderecoId { get; private set; }
    }
}