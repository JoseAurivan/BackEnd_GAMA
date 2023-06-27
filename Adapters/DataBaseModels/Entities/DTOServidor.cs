using Core.Entities.Abstract;
using Infrastructure.DataBaseModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DTOServidor 
    {

        public DTOServidor()
        {

        }

        public int UserId { get; set; }
        public DTOUser? User { get; set; }
        public string Matricula { get;  set; }
        public DTOSecretaria? Secretaria { get;  set; }
        public int SecretariaId { get; set; }
        public DTOCargo? Cargo { get;  set; }
        public int CargoId { get;  set; }



    }
}
