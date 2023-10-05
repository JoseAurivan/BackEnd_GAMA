namespace Core.Entities
{
    public class DTOEndereco
    {
        public DTOEndereco()
        {

        }

        public DTOEndereco(int id)
        {
            Id = id;
        }
        public int Id { get;  set; }
        public string Logradouro { get;  set; }
        public string CEP { get;  set; }
        public string Rua { get;  set; }
        public string Bairro { get;  set; }

        public DTOEndereco(string logradouro, string cEP, string rua, string bairro) 
        {
            Logradouro = logradouro;
            CEP = cEP;
            Rua = rua;
            Bairro = bairro;
        }

        public DTOEndereco(int id, string logradouro, string cEP, string rua, string bairro)
        {
            Id = id;
            Logradouro = logradouro;
            CEP = cEP;
            Rua = rua;
            Bairro = bairro;
        }

        public Endereco ConverterDTOParaModel(int id, string logradouro, string cep, string rua, string bairro)
        {
            return new Endereco
            {
                Id= id,
                Logradouro= logradouro,
                CEP = cep,
                Rua = rua,
                Bairro = bairro
            };
        }
    }
}