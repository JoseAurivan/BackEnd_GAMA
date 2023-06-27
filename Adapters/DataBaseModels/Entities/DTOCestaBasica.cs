using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataBaseModels.Entities;

namespace Core.Entities
{
    public class DTOCestaBasica 
    {
        public DTOCestaBasica()
        {

        }
        public int Id { get; set; }

        public int SolcitacaoID { get; set; }
        public DTOSolicitacao? Solicitacao { get; set; }
        public DTOEndereco? Endereco { get;  set; }
        public DTOFamilia? Familia { get;  set; }
        public int EnderecoId { get;  set; }

    }
}
