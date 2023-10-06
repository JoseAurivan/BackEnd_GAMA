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
            try
            {
                DTOCargo cargo = await context.Cargos.FirstOrDefaultAsync(x => x.Id == Cargo.Id);
                if (cargo is not null)
                    context.Cargos.Remove(cargo);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Cargo> GetCargoByIdAsync(int id)
        {
            try
            {
                var cargoDTO = await context.Cargos.FirstOrDefaultAsync(x => x.Id == id);
                return cargoDTO.ConverterDTOParaModel(cargoDTO);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Cargo>> GetCargos()
        {
            try
            {
                var DTOCargos = await context.Cargos.AsNoTracking().ToListAsync();

                List<Cargo> cargos = new List<Cargo>();
                foreach (var cargoDTO in DTOCargos)
                {
                    var modelCargo = cargoDTO.ConverterDTOParaModel(cargoDTO);
                    cargos.Add(modelCargo);
                }

                return cargos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveCargoAsync(Cargo Cargo)
        {
            try
            {
                DTOCargo cargo = new DTOCargo(Cargo.Nome, Cargo.Salario, Cargo.Hierarquia);

                if (Cargo.Id == default)
                {
                    context.Cargos.Add(cargo);
                }
                else
                {
                    cargo.Id = Cargo.Id;
                    context.Entry(cargo).State = EntityState.Modified;
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
