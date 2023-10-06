using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteFront
{
    public class ReclamacaoViewModel
    {
        public string Texto { get; set; }
        public string AutorCPF { get; set; }
        public DateTime DataCriacao { get; set; }
        public int SecretariaId { get; set; }
    }
}
