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

        public DTOServidor(int id)
        {
            UserId= id;
        }

        public DTOServidor(int userId, string matricula, int secretariaId, int cargoId)
        {
            UserId = userId;
            Matricula = matricula;
            SecretariaId = secretariaId;
            CargoId = cargoId;
        }

        public int UserId { get; set; }
        public DTOUser? User { get; set; }
        public string Matricula { get;  set; }
        public DTOSecretaria? Secretaria { get;  set; }
        public int SecretariaId { get; set; }
        public DTOCargo? Cargo { get;  set; }
        public int CargoId { get;  set; }

        public Servidor ConverterDTOParaModel(DTOServidor servidor, Cargo cargo, Secretaria secretaria )
        {
            return new Servidor();
        }

        public Servidor ConverterDTOParaModel(DTOServidor servidor, Cargo cargo)
        {
            return new Servidor(servidor.Matricula,cargo);
        }

        public Servidor ConverterDTOParaModel(DTOServidor servidor)
        {
            return new Servidor(servidor.Matricula);
        }
    }
}
