using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cidadao : User
    {
        public string PISPASEP { get; private set; }
        public int EnderecoId { get;private set; }

        public Cidadao()
        {

        }

        public Reclamacao RealizarReclamacao(string reclamacao, Secretaria secretaria)
        {
            return null;
        }



    }
}
