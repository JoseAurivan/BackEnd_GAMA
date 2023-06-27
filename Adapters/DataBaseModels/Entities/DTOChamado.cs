using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataBaseModels.Entities;

namespace Core.Entities
{
    public class DTOChamado 
    {
        public DTOChamado()
        {

        }
        public int Id { get; set; }
        public int SolicitacaoId { get; set; }
        public DTOSolicitacao? Solicitacao { get; set; } 
        public StatusAtendimento StatusAtendimento { get;  set; }
        public string Telefone { get;  set; }

    }

}
