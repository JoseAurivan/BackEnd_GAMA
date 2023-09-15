using Core.Entities;
using Core.Repository;
using Infrastructure.DataBaseModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReclamacaoRepositorySQL : IReclamacaoRepository
    {
        private Context context;

        public ReclamacaoRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteReclamacaoAsync(Reclamacao Reclamacao)
        {
            var reclamacaoDTO = await context.Reclamacoes.FirstOrDefaultAsync(x => x.Id == Reclamacao.Id);
            if (reclamacaoDTO is not null)
                context.Reclamacoes.Remove(reclamacaoDTO);
            await context.SaveChangesAsync();
        }

        public async Task<Reclamacao> GetReclamacaoByIdAsync(int id)
        {
            var reclamacao = await context.Reclamacoes.Where(x => x.Id == id)
                .Include(x => x.Autor)
                .ThenInclude(x => x.User)
                .Include(x => x.Destino).FirstOrDefaultAsync();

            return reclamacao.ConverterDTOParaModel(reclamacao);
        }

        public async Task<IEnumerable<Reclamacao>> GetReclamacaos()
        {
            var reclamacoesDTO = await context.Reclamacoes
                .Include(x => x.Autor)
                .ThenInclude(x => x.User)
                .Include(x => x.Destino).ToListAsync();

            List<Reclamacao> reclamacoes = new List<Reclamacao>();

            foreach(var reclamacao in reclamacoesDTO)
            {
                reclamacoes.Add(reclamacao.ConverterDTOParaModel(reclamacao));
            }

            return reclamacoes;
        }

        public async Task SaveReclamacaoAsync(Reclamacao Reclamacao)
        {
            var autor = await  context.Cidadoes.Where(x => Reclamacao.Autor.Id == x.UserId).Include(x => x.User).FirstOrDefaultAsync();
            var destino = await context.Secretarias.Where(x => Reclamacao.Destino.Id == x.Id).FirstOrDefaultAsync();

            var reclamacaoDTO = new DTOReclamacao(Reclamacao.Id,autor.UserId,Reclamacao.Texto,Reclamacao.DataCriacao,destino.Id);

            if (Reclamacao.Id == default) context.Reclamacoes.Add(reclamacaoDTO);
            else context.Entry(Reclamacao).State = EntityState.Modified;

            context.Entry(autor).State = EntityState.Modified;
            context.Entry(destino).State = EntityState.Unchanged;

            await context.SaveChangesAsync();
        }
    }
}
