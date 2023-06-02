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
        public StatusAtendimento StatusAtendimento { get; private set; }
        public string Telefone { get; private set; }

        public int AtendenteId { get; private set; }
        public int SolicitanteId { get; private set; }
    }

    public enum StatusAtendimento
    {
        EmDia,
        Atrasada,
        Atendida
    }
}
