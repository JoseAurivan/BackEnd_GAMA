using Core.Entities;
using Core.Repository;
using Infrastructure.DataBaseModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ServidorRepositorySQL : IServidorRepository
    {
        private Context context;

        public async Task<Servidor> AuthenticateServidor(string matricula, string password)
        {
            var servidorDTO = await context.Servidores
            .Include(x => x.User)
            .Where(x => x.Matricula == matricula && x.User.Senha == password)
            .FirstOrDefaultAsync();

            if (servidorDTO is not null)
                return servidorDTO.ConverterDTOParaModel(servidorDTO);

            return null;
        }

        public async Task DeleteServidorAsync(Servidor Servidor)
        {
            var servidorDTO = new DTOUser(Servidor.Id);
            context.Users.Remove(servidorDTO);
            await context.SaveChangesAsync();
        }

        public async Task<Servidor> GetServidorByIdAsync(int id)
        {
            var servidorDTO = await context.Servidores
                .Where(x => x.UserId == id)
                .Include(x => x.User)
                .Include(x => x.Secretaria)
                .Include(x => x.Cargo)
                .FirstOrDefaultAsync();

            var secretariaDTO = servidorDTO.Secretaria;
            var cargoDTO = servidorDTO.Cargo;

            var secretaria = secretariaDTO.ConverterDTOParaModel(secretariaDTO);
            var cargo = cargoDTO.ConverterDTOParaModel(cargoDTO);

            return servidorDTO.ConverterDTOParaModel(servidorDTO, cargo, secretaria);
        }

        public async Task<IEnumerable<Servidor>> GetServidors()
        {
            var servidoresDTO = await context.Servidores
                .Include(x => x.User)
                .Include(x => x.Cargo)
                .ToListAsync();

            List<Servidor> servidores = new List<Servidor>();

            foreach (var servidorDTO in servidoresDTO)
            {
                var cargoDTO = servidorDTO.Cargo;
                var cargo = cargoDTO.ConverterDTOParaModel(cargoDTO);

                servidores.Add(servidorDTO.ConverterDTOParaModel(servidorDTO, cargo));
            }

            return servidores;
        }

        public async Task SaveServidorAsync(Servidor Servidor)
        {
            var userDTO = new DTOUser(Servidor.Id, Servidor.Nome, Servidor.CPF, Servidor.Senha, new DTOEndereco(), Servidor.Email, Servidor.Telefone);
            var servidorDTO = new DTOServidor(Servidor.Id, Servidor.Matricula, Servidor.Secretaria.Id, Servidor.Cargo.Id);
            if (servidorDTO.UserId == default)
            {
                context.Users.Add(userDTO);
                context.Servidores.Add(servidorDTO);
            }
            else
            {
                context.Entry(servidorDTO).State = EntityState.Modified;
                context.Entry(userDTO).State = EntityState.Modified;
            }

            await context.SaveChangesAsync();
        }
    }
}
