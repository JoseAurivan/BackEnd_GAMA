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
        public DTOChamado(DTOSolicitacao? solicitacao, StatusAtendimento statusAtendimento, string telefone)
        {
            Solicitacao = solicitacao;
            StatusAtendimento = statusAtendimento;
            Telefone = telefone;
        }

        public int SolicitacaoId { get; set; }
        public DTOSolicitacao? Solicitacao { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        public string Telefone { get; set; }

        public Chamado ConverterDTOParaModel(DTOChamado chamadoDTO, DTOSecretaria secretaria, DTOUser user, DTOServidor servidor)
        {
            Chamado chamado = new Chamado(chamadoDTO.StatusAtendimento, chamadoDTO.Telefone, chamadoDTO.Solicitacao.StatusSolicitacao,
                secretaria.ConverterDTOParaModel(secretaria), chamadoDTO.Solicitacao.NumeroProtocolo, chamadoDTO.Solicitacao.Descricao, user.ConverterParaModel(user),
               servidor.ConverterDTOParaModel(servidor), chamadoDTO.Solicitacao.Inicio);

            return chamado;
        }

        public Chamado ConverterDTOParaModel(DTOChamado chamadoDTO, DTOSecretaria secretaria, DTOUser user)
        {
            Chamado chamado = new Chamado(chamadoDTO.StatusAtendimento, chamadoDTO.Telefone, chamadoDTO.Solicitacao.StatusSolicitacao,
                secretaria.ConverterDTOParaModel(secretaria), chamadoDTO.Solicitacao.NumeroProtocolo, chamadoDTO.Solicitacao.Descricao, user.ConverterParaModel(user),
                chamadoDTO.Solicitacao.Inicio);

            return chamado;
        }

    }

}
