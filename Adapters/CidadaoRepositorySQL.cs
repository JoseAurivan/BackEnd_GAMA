using Core.Entities;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CidadaoRepositorySQL : ICidadaoRepository
    {
        private Context context;

        public CidadaoRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteCidadaoAsync(DTOCidadao cidadao)
        {
            context.Cidadoes?.Remove(cidadao);
            await context.SaveChangesAsync();
        }

        public async Task<DTOCidadao>? GetCidadaoByIdAsync(int id)
        {
            return await context.Cidadoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<DTOCidadao>> GetCidadaos()
        {
            return await context.Cidadoes.ToListAsync<DTOCidadao>();
        }


        public async Task SaveCidadaoAsync(DTOCidadao cidadao)
        {
            if (cidadao.Id == default) await context.Cidadoes.AddAsync(cidadao);
            else context.Entry(cidadao).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}