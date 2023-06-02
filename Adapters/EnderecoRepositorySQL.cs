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
    public class EnderecoRepositorySQL : IEnderecoRepository
    {
        private Context context;

        public EnderecoRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteEnderecoAsync(Endereco Endereco)
        {
            context.Enderecos.Remove(Endereco);
            await context.SaveChangesAsync();
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            return await context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Endereco>> GetEnderecos()
        {
            return await context.Enderecos.ToListAsync();
        }

        public async Task SaveEnderecoAsync(Endereco Endereco)
        {
            if (Endereco.Id == default) await context.Enderecos.AddAsync(Endereco);
            else context.Entry(Endereco).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
