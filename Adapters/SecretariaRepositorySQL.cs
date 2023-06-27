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

        public async Task DeleteSecretariaAsync(DTOSecretaria Secretaria)
        {
            context.Secretarias.Remove(Secretaria);
            await context.SaveChangesAsync();
        }

        public async Task<DTOSecretaria> GetSecretariaByIdAsync(int id)
        {
            return await context.Secretarias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<DTOSecretaria>> GetSecretarias()
        {
            return await context.Secretarias.ToListAsync();
        }

        public async Task SaveSecretariaAsync(DTOSecretaria Secretaria)
        {
            if (Secretaria.Id == default) await context.Secretarias.AddAsync(Secretaria);
            else context.Entry(Secretaria).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
