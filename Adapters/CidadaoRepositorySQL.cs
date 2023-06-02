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

        public async Task DeleteCidadaoAsync(Cidadao cidadao)
        {
            context.Cidadoes?.Remove(cidadao);
            await context.SaveChangesAsync();
        }

        public async Task<Cidadao>? GetCidadaoByIdAsync(int id)
        {
            return await context.Cidadoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cidadao>> GetCidadaos()
        {
            return await context.Cidadoes.ToListAsync<Cidadao>();
        }


        public async Task SaveCidadaoAsync(Cidadao cidadao)
        {
            if (cidadao.Id == default) await context.Cidadoes.AddAsync(cidadao);
            else context.Entry(cidadao).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}