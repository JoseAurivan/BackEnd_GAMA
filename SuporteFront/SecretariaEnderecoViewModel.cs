using Core.Entities;

namespace SuporteFront
{
    public class SecretariaEnderecoViewModel
    {
        public SecretariaEnderecoViewModel()
        {
            Secretaria = new Secretaria();
            Endereco = new Endereco();
        }
        public Secretaria Secretaria { get; set; }
        public Endereco Endereco { get; set; }
    }
}