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
            DTOCargo cargo = new DTOCargo(Cargo.Nome, Cargo.Salario, Cargo.Hierarquia);
            context.Cargos.Remove(cargo);
            await context.SaveChangesAsync();
        }

        public async Task<Cargo> GetCargoByIdAsync(int id)
        {
            var cargoDTO =  await context.Cargos.FirstOrDefaultAsync(x => x.Id == id);
            return cargoDTO.ConverterDTOParaModel(cargoDTO);

        }

        public async Task<IEnumerable<Cargo>> GetCargos()
        {
            var DTOCargos =  await context.Cargos.AsNoTracking().ToListAsync();

            List<Cargo> cargos = new List<Cargo>();
            foreach(var cargoDTO in DTOCargos)
            {
                var modelCargo = cargoDTO.ConverterDTOParaModel(cargoDTO);
                cargos.Add(modelCargo);
            }

            return cargos;
        }

        public async Task SaveCargoAsync(Cargo Cargo)
        {
            if (id == default) await context.Cargos.AddAsync(Cargo);
            else context.Entry(Cargo).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}
