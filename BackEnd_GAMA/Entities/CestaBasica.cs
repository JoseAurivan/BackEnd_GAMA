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
        public Endereco Endereco { get; private set; }
        public string SituacaoDescricao { get; private set; }
        public Familia Familia { get; private set; }
        public int EnderecoId { get; private set; }

    }
}
