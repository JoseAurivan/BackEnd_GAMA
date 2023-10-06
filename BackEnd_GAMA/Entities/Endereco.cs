namespace Core.Entities
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public int Id { get; set; }
        public string Logradouro { get;  set; }
        public string CEP { get;  set; }
        public string Rua { get;  set; }
        public string Bairro { get;  set; }
    }
}