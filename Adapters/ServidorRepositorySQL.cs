using Core.Entities;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ServidorRepositorySQL:IServidorRepository
    {
        private Context context;

        public async Task DeleteServidorAsync(Servidor Servidor)
        {
            context.Servidores.Remove(Servidor);
            await context.SaveChangesAsync();
        }

        public async Task<Servidor> GetServidorByIdAsync(int id)
        {
            return await context.Servidores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Servidor>> GetServidors()
        {
            return await context.Servidores.ToListAsync();
        }

        public async Task SaveServidorAsync(Servidor Servidor)
        {
            if (Servidor.Id == default) await context.Servidores.AddAsync(Servidor);
            else context.Entry(Servidor).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
