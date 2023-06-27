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
    public class CestaBasicaRepositorySQL : ICestaBasicaRepository
    {
        private Context context;

        public CestaBasicaRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteCestaBasicaAsync(DTOCestaBasica CestaBasica)
        {
            context.CestaBasicas.Remove(CestaBasica);
            await context.SaveChangesAsync();
        }

        public async Task<DTOCestaBasica> GetCestaBasicaByIdAsync(int id)
        {
            return await context.CestaBasicas.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<IEnumerable<DTOCestaBasica>> GetCestaBasicas()
        {
            return await context.CestaBasicas.ToListAsync();
        }

        public async Task SaveCestaBasicaoAsync(DTOCestaBasica CestaBasica)
        {
            if (CestaBasica.Id == default) await context.CestaBasicas.AddAsync(CestaBasica);
            else context.Entry(CestaBasica).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
