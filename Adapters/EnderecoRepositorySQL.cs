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
            DTOEndereco endereco = new DTOEndereco(Endereco.Id);
            context.Enderecos.Remove(endereco);
            await context.SaveChangesAsync();
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            var enderecoDTO =  await context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
            return enderecoDTO.ConverterDTOParaModel(enderecoDTO.Id,enderecoDTO.Logradouro,enderecoDTO.CEP,enderecoDTO.Rua,enderecoDTO.Bairro);
        }

        public async Task<IEnumerable<Endereco>> GetEnderecos()
        {
            List<Endereco> enderecos = new List<Endereco>();
            var DTOenderecos =  await context.Enderecos.ToListAsync();
            foreach(DTOEndereco enderecoDTO in DTOenderecos)
            {
                enderecos.Add(enderecoDTO.ConverterDTOParaModel(enderecoDTO.Id, enderecoDTO.Logradouro, enderecoDTO.CEP, enderecoDTO.Rua, enderecoDTO.Bairro));
            }
            return enderecos;
        }

        public async Task SaveEnderecoAsync(Endereco Endereco)
        {
            DTOEndereco enderecoDTO = new DTOEndereco(Endereco.Logradouro,Endereco.CEP,Endereco.Rua,Endereco.Bairro);
            if (Endereco.Id == default) await context.Enderecos.AddAsync(enderecoDTO);
            else context.Entry(enderecoDTO).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
