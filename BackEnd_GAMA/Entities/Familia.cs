namespace Core.Entities
{
    public class Familia
    {
        public Familia()
        {
            Membros = new List<Cidadao>();
        }

        public int Id { get;  set; }
        public ICollection<Cidadao> Membros { get;  set; }
        public ICollection<CestaBasica> Cestas { get;  set; }
        public Endereco Endereco { get; private set; }
        public int EnderecoId { get; private set; }
    }
}