﻿using Core.Entities;
using Core.Repository;
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
            context.Reclamacoes.Remove(Reclamacao);
            await context.SaveChangesAsync();
        }

        public async Task<Reclamacao> GetReclamacaoByIdAsync(int id)
        {
            return await context.Reclamacoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Reclamacao>> GetReclamacaos()
        {
            return await context.Reclamacoes.ToListAsync();
        }

        public async Task SaveReclamacaoAsync(Reclamacao Reclamacao)
        {
            if (Reclamacao.Id == default) await context.Reclamacoes.AddAsync(Reclamacao);
            else context.Entry(Reclamacao).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}