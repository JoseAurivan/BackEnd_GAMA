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

        public ServidorRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task<Servidor> AuthenticateServidor(string matricula, string password)
        {
            try
            {
                var servidorDTO = await context.Servidores
                .Include(x => x.User)
                .Where(x => x.Matricula == matricula && x.User.Senha == password)
                .FirstOrDefaultAsync();

                if (servidorDTO is not null)
                    return servidorDTO.ConverterDTOParaModel(servidorDTO);

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteServidorAsync(Servidor Servidor)
        {
            try
            {
                var userDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == Servidor.Id);

                context.Users.Remove(userDTO);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Servidor> GetServidorByIdAsync(int id)
        {
            try { 
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
            }catch(Exception ex) { throw; }
        }

        public async Task<Servidor> GetServidorByMatriculaAsync(string matricula)
        {
            try
            {
                var servidorDTO = await context.Servidores
                    .Where(x => x.Matricula == matricula)
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
            catch (Exception ex) { throw; }
        }

        public async Task<IEnumerable<Servidor>> GetServidors()
        {
            try
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
            catch (Exception ex) { throw; }
        }

        public async Task SaveServidorAsync(Servidor Servidor)
        {
            try
            {
                var userDTO = new DTOUser(Servidor.Nome, Servidor.CPF, Servidor.Senha, Servidor.Email, Servidor.Telefone);
                var servidorDTO = new DTOServidor(Servidor.Matricula, Servidor.Secretaria.Id, Servidor.Cargo.Id);
                if (Servidor.Id == default)
                {
                    context.Users.Add(userDTO);
                    await context.SaveChangesAsync();
                    servidorDTO.UserId = userDTO.Id;
                    context.Servidores.Add(servidorDTO);
                    await context.SaveChangesAsync();

                }
                else
                {
                    userDTO.Id = Servidor.Id;
                    servidorDTO.UserId = userDTO.Id;
                    context.Entry(userDTO).State = EntityState.Modified;
                    context.Entry(servidorDTO).State = EntityState.Modified;

                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex) { throw; }
        }
    }
}
