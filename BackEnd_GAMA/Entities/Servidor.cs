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

        public string Matricula { get;  set; }
        public Secretaria Secretaria { get; private set; }
        public Cargo Cargo { get; private set; }



    }
}
