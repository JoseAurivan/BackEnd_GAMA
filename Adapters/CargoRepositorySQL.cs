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
    public class CargoRepositorySQL : ICargoRepository
    {
        private Context context;

        public CargoRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteCargoAsync(Cargo Cargo)
        {
            context.Cargos.Remove(Cargo);
            await context.SaveChangesAsync();
        }

        public async Task<Cargo> GetCargoByIdAsync(int id)
        {
            return await context.Cargos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cargo>> GetCargos()
        {
            return await context.Cargos.ToListAsync();
        }

        public async Task SaveCargoAsync(Cargo Cargo)
        {
            if (Cargo.Id == default) await context.Cargos.AddAsync(Cargo);
            else context.Entry(Cargo).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
