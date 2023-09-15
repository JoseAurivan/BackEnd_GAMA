using Core.Entities;
using Core.Entities.Abstract;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SecretariaRepositorySQL:ISecretariaRepository
    {
        private Context context;

        public SecretariaRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteSecretariaAsync(Secretaria Secretaria)
        {
            var secretariaDTO = await context.Secretarias.FirstOrDefaultAsync(x => x.Id== Secretaria.Id);
            if(secretariaDTO is not null)
                context.Secretarias.Remove(secretariaDTO);
            await context.SaveChangesAsync();
        }

        public async Task<Secretaria> GetSecretariaByIdAsync(int id)
        {
            var secretariaDTO = await context.Secretarias.Where(x => x.Id == id)
                 .Include(x => x.Servidores)
                 .ThenInclude(x => x.User)
                 .Include(x => x.Endereco)
                 .Include(x => x.Solicitacoes)
                 .FirstOrDefaultAsync();

            var enderecoDTO = secretariaDTO.Endereco;
            var endereco = enderecoDTO.ConverterDTOParaModel(enderecoDTO.Id, enderecoDTO.Logradouro, enderecoDTO.CEP, enderecoDTO.Rua, enderecoDTO.Bairro);
            List<Servidor> servidores = new List<Servidor>();
            List<Solicitacao> solicitacaos = new List<Solicitacao>();

            foreach(var servidorDTO in secretariaDTO.Servidores)
            {
                servidores.Add(servidorDTO.ConverterDTOParaModel(servidorDTO));
            }

            foreach(var solicitacaoDTO in secretariaDTO.Solicitacoes)
            {
                solicitacaos.Add(solicitacaoDTO.ConverterDTOParaModel()); 
            }

            return secretariaDTO.ConverterDTOParaModel(secretariaDTO,solicitacaos,servidores,endereco);
            
        }

        public async Task<IEnumerable<Secretaria>> GetSecretarias()
        {
            var secretariasDTO = await context.Secretarias.ToListAsync();
            List<Secretaria> secretarias = new List<Secretaria>();

            foreach(var secretariaDTO in secretariasDTO)
            {
                secretarias.Add(secretariaDTO.ConverterDTOParaModel(secretariaDTO));
            }

            return secretarias;
        }

        public async Task SaveSecretariaAsync(Secretaria Secretaria)
        {
            var secretariaDTO = new DTOSecretaria(Secretaria.Nome, Secretaria.Telefone, Secretaria.CNPJ, Secretaria.Endereco.Id);
            if (Secretaria.Id == default) context.Secretarias.Add(secretariaDTO);
            else context.Entry(secretariaDTO).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

    }
}
