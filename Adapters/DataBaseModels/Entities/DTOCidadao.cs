﻿using Core.Entities.Abstract;
using Infrastructure.DataBaseModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DTOCidadao 
    {
        public DTOUser? User { get; set; }
        public int UserId { get; set; }
        public string PISPASEP { get;  set; }
        public DTOFamilia? Familia { get; set; }

        public DTOCidadao()
        {

        }



    }
}