using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteFront
{
    public class ServidorViewModel
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Matricula { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int SecretariaId { get; set; }
        public int CargoId {get;set;}

    }
}
