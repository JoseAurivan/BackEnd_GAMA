using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Servidor : User
    {

        public Servidor()
        {

        }

        public string Matricula { get; private set; }
        public Secretaria Secretaria { get; private set; }
        public Cargo Cargo { get; private set; }
        public int CargoId { get; private set; }



    }
}
