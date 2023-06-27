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
    public class FamiliaRepositorySQL : IFamiliaRepository
    {
        private Context context;
        public async Task DeleteFamiliaAsync(DTOFamilia Familia)
        {
            context.Familias.Remove(Familia);
            await context.SaveChangesAsync();
        }

        public async Task<DTOFamilia> GetFamiliaByIdAsync(int id)
        {
            return await context.Familias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<DTOFamilia>> GetFamilias()
        {
            return await context.Familias.ToListAsync();
        }

        public async Task SaveFamiliaAsync(DTOFamilia Familia)
        {
            if (Familia.Id == default) await context.Familias.AddAsync(Familia);
            else context.Entry(Familia).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
