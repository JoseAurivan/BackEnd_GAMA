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

        public CestaBasica(Endereco endereco, Familia familia, int idSolicitacao, string numeroProtocolo, string descricao, StatusSolicitacao statusSolicitacao)
        {
            Id = idSolicitacao;   
            Endereco = endereco;
            Familia = familia;
            NumeroProtocolo = numeroProtocolo; 
            Descricao = descricao;
            StatusSolicitacao = statusSolicitacao;

        }

        public Endereco Endereco { get;  set; }
        public Familia Familia { get;  set; }

    }
}
