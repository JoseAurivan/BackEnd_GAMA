using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Infrastructure.DataBaseModels.Entities;

namespace Core.Entities
{
    public class DTOCestaBasica 
    {
        public DTOCestaBasica()
        {

        }

        public int SolcitacaoID { get; set; }
        public DTOSolicitacao? Solicitacao { get; set; }
        public DTOEndereco? Endereco { get;  set; }
        public DTOFamilia? Familia { get;  set; }
        public int FamiliaId { get; set; }
        public int EnderecoId { get;  set; }

        public DTOCestaBasica(int solcitacaoID, int enderecoId)
        {

            SolcitacaoID = solcitacaoID;
            EnderecoId = enderecoId;
        }

        public DTOCestaBasica( DTOSolicitacao? solicitacao, DTOEndereco? endereco, DTOFamilia? familia)
        {
            Solicitacao = solicitacao;
            Endereco = endereco;
            Familia = familia;
        }

        public CestaBasica ConverterDTOParaModel( Endereco endereco, Familia familia, int idSolcitacao, string numeroProtocolo, string descricao, StatusSolicitacao statusSolicitacao)
        {
            CestaBasica cestaBasica = new CestaBasica(endereco, familia, idSolcitacao,numeroProtocolo, descricao, statusSolicitacao);

            return cestaBasica;
        }
    }
}
