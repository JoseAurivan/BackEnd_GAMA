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
            try
            {
                DTOEndereco endereco = new DTOEndereco(Endereco.Id, Endereco.Logradouro, Endereco.CEP, Endereco.Rua, Endereco.Bairro);
                context.Enderecos.Remove(endereco);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            try { 
            var enderecoDTO = await context.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return enderecoDTO.ConverterDTOParaModel(enderecoDTO.Id, enderecoDTO.Logradouro, enderecoDTO.CEP, enderecoDTO.Rua, enderecoDTO.Bairro);
            }catch(Exception ex) { throw; }
        }

        public async Task<IEnumerable<Endereco>> GetEnderecos()
        {
            try
            {
                List<Endereco> enderecos = new List<Endereco>();
                var DTOenderecos = await context.Enderecos.ToListAsync();
                foreach (DTOEndereco enderecoDTO in DTOenderecos)
                {
                    enderecos.Add(enderecoDTO.ConverterDTOParaModel(enderecoDTO.Id, enderecoDTO.Logradouro, enderecoDTO.CEP, enderecoDTO.Rua, enderecoDTO.Bairro));
                }
                return enderecos;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<int> SaveEnderecoAsync(Endereco Endereco)
        {
            try
            {
                DTOEndereco enderecoDTO = new DTOEndereco(Endereco.Logradouro, Endereco.CEP, Endereco.Rua, Endereco.Bairro);
                if (Endereco.Id == default) context.Enderecos.Add(enderecoDTO);
                else
                {
                    enderecoDTO.Id = Endereco.Id;
                    context.Entry(enderecoDTO).State = EntityState.Modified;
                }

                await context.SaveChangesAsync();
                return enderecoDTO.Id;
            }
            catch (Exception ex) { throw; }
        }
    }
}
