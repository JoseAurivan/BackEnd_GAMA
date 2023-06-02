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
        public async Task DeleteFamiliaAsync(Familia Familia)
        {
            context.Familias.Remove(Familia);
            await context.SaveChangesAsync();
        }

        public async Task<Familia> GetFamiliaByIdAsync(int id)
        {
            return await context.Familias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Familia>> GetFamilias()
        {
            return await context.Familias.ToListAsync();
        }

        public async Task SaveFamiliaAsync(Familia Familia)
        {
            if (Familia.Id == default) await context.Familias.AddAsync(Familia);
            else context.Entry(Familia).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
