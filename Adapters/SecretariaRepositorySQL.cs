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
    public class SecretariaRepositorySQL:ISecretariaRepository
    {
        private Context context;

        public SecretariaRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteSecretariaAsync(Secretaria Secretaria)
        {
            context.Secretarias.Remove(Secretaria);
            await context.SaveChangesAsync();
        }

        public async Task<Secretaria> GetSecretariaByIdAsync(int id)
        {
            return await context.Secretarias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Secretaria>> GetSecretarias()
        {
            return await context.Secretarias.ToListAsync();
        }

        public async Task SaveSecretariaAsync(Secretaria Secretaria)
        {
            if (Secretaria.Id == default) await context.Secretarias.AddAsync(Secretaria);
            else context.Entry(Secretaria).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
