using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteFront
{
    public class ChamadoViewModel
    {
        public int SecretariaId { get; set; }
        public StatusAtendimento Atendimento { get; set; }
        public StatusSolicitacao Solicitacao { get; set; }
        public DateTime DataAbertura {get;set;}
        public string Matricula { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
    }
}
