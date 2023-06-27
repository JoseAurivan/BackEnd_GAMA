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
    public class ChamadoRepositorySQL : IChamadoRepository
    {
        private Context context;

        public ChamadoRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteChamadoAsync(DTOChamado Chamado)
        {
            context.Chamados.Remove(Chamado);
            await context.SaveChangesAsync();
        }

        public async Task<DTOChamado> GetChamadoByIdAsync(int id)
        {
            return await context.Chamados.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<DTOChamado>> GetChamados()
        {
            return await context.Chamados.ToListAsync();
        }

        public async Task SaveChamadooAsync(DTOChamado Chamado)
        {
            if (Chamado.Id == default) await context.Chamados.AddAsync(Chamado);
            else context.Entry(Chamado).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
