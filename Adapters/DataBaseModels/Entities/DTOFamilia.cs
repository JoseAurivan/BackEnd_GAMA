namespace Core.Entities
{
    public class DTOFamilia
    {
        public DTOFamilia()
        {
            Membros = new List<DTOCidadao>();
            Cestas = new List<DTOCestaBasica>();
        }

        public DTOFamilia(int id)
        {
            Id = id;
        }

        public int Id { get;  set; }
        public ICollection<DTOCidadao> Membros { get;  set; }
        public ICollection<DTOCestaBasica> Cestas { get;  set; }
        public DTOEndereco Endereco { get;  set; }
        public int EnderecoId { get;  set; }

        public Familia ConverterDTOParaModel(DTOFamilia familia, Endereco endereco)
        {
            return new Familia(familia.Id,endereco);
        }
    }
}