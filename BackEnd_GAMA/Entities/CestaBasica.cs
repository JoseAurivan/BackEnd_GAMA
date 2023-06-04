using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Core.Entities
{
    public class CestaBasica : Solicitacao
    {
        public CestaBasica()
        {

        }
        public Endereco Endereco { get;  set; }
        public string SituacaoDescricao { get;  set; }
        public Familia Familia { get;  set; }
        public int EnderecoId { get;  set; }

    }
}
