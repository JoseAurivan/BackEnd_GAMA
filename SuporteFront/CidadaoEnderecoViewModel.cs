using Core.Entities;

namespace SuporteFront
{
    public class CidadaoEnderecoViewModel
    {
        public CidadaoEnderecoViewModel()
        {
            Cidadao = new Cidadao();
            Endereco = new Endereco();
        }
        public Cidadao? Cidadao { get; set; }
        public Endereco? Endereco { get; set; }
    }
}