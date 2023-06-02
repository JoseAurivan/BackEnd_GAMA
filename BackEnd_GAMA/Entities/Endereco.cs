namespace Core.Entities
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public int Id { get;  set; }
        public string Logradouro { get; private set; }
        public string CEP { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
    }
}