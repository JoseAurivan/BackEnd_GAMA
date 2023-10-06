namespace Core.Entities
{
    public class Familia
    {
        public Familia()
        {
            Membros = new List<Cidadao>();
            Cestas = new List<CestaBasica>();
        }

        public Familia(int id, Endereco endereco)
        {
            Id = id;
            Endereco = endereco;
        }

        public int Id { get; set; }
        public ICollection<Cidadao> Membros { get;  set; }
        public ICollection<CestaBasica> Cestas { get;  set; }
        public Endereco Endereco { get; private set; }
    }
}