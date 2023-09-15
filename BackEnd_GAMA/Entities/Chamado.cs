using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Core.Entities
{
    public class Chamado : Solicitacao
    {
        public Chamado()
        {

        }
        public Chamado(StatusAtendimento statusAtendimento, string telefone, StatusSolicitacao statusSolicitacao,
            Secretaria secretaria, string numeroProtocolo, string descricao, User user, Servidor atendidoPor, DateTime inicio)
        {
            StatusAtendimento = statusAtendimento;
            Telefone = telefone;
            SecretariaDestino = secretaria;
            StatusSolicitacao = statusSolicitacao;
            SecretariaDestino = secretaria;
            NumeroProtocolo = numeroProtocolo;
            Descricao = descricao;
            SolicitadoPor = user;
            AtendidoPor = atendidoPor;
            Inicio = inicio;



        }

        public StatusAtendimento StatusAtendimento { get;  set; }
        public string Telefone { get;  set; }
}

    

    public enum StatusAtendimento
    {
        EmDia,
        Atrasada,
        Atendida
    }
}
