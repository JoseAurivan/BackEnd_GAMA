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
        public StatusAtendimento StatusAtendimento { get;  set; }
        public string Telefone { get;  set; }

        public int AtendenteId { get;  set; }
        public int SolicitanteId { get;  set; }
    }

    public enum StatusAtendimento
    {
        EmDia,
        Atrasada,
        Atendida
    }
}
