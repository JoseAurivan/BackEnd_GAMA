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
    public class CestaBasicaRepositorySQL : ICestaBasicaRepository
    {
        private Context context;

        public CestaBasicaRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteCestaBasicaAsync(CestaBasica CestaBasica)
        {
            
            var solicitacaoDTO = await context.Solicitacoes.Where(x => x.Id == CestaBasica.Id).FirstOrDefaultAsync();
            if(solicitacaoDTO is not null)
                context.Solicitacoes.Remove(solicitacaoDTO);
            await context.SaveChangesAsync();
        }

        public async Task<CestaBasica> GetCestaBasicaByIdAsync(int id)
        {
            var cestaBasicaDTO = await context.CestaBasicas.Include(x => x.Solicitacao).ThenInclude(x => x.SolicitadoPor)
                .Include(x => x.Endereco)
                .Include(x => x.Familia)
                .FirstOrDefaultAsync(x => x.SolcitacaoID == id);

            return PreencherCestaBasica(cestaBasicaDTO);

        }

        public async Task<IEnumerable<CestaBasica>> GetCestaBasicas()
        {
            var DTOcestabasicaList = await context.CestaBasicas.ToListAsync();
            List<CestaBasica> cestaBasicas = new List<CestaBasica>();
            foreach (DTOCestaBasica cestaBasicaDTO in DTOcestabasicaList)
            {
                cestaBasicas.Add(PreencherCestaBasica(cestaBasicaDTO));
            }

            return cestaBasicas;
        }

        public async Task SaveCestaBasicaoAsync(CestaBasica CestaBasica)
        {
            var secretaria = await context.Secretarias.FirstOrDefaultAsync(x=> x.Id == CestaBasica.SecretariaDestino.Id);
            var user = await context.Users.FirstOrDefaultAsync(x=> x.Id==CestaBasica.SolicitadoPor.Id);
            var servidor = await context.Servidores.FirstOrDefaultAsync( x=> x.UserId == CestaBasica.AtendidoPor.Id);

            //PREENCHER DTOs com IDs
            var solicitacao = new DTOSolicitacao(CestaBasica.Descricao,CestaBasica.NumeroProtocolo,CestaBasica.StatusSolicitacao,secretaria,
                user, servidor, CestaBasica.Inicio, CestaBasica.Fim);

            var familia = await context.Familias.FirstOrDefaultAsync(x => x.Id == CestaBasica.Familia.Id);
            var endereco = await context.Enderecos.FirstOrDefaultAsync( x=> x.Id == CestaBasica.Endereco.Id);
            var cestaBasicaDTO = new DTOCestaBasica(solicitacao,endereco,familia);

            familia.Cestas.Add(cestaBasicaDTO);
            secretaria.Solicitacoes.Add(solicitacao);
            user.Solicitacao.Add(solicitacao);

            if (CestaBasica.Id == default)
            {
                context.Solicitacoes.Add(solicitacao);
                context.CestaBasicas.Add(cestaBasicaDTO);
            }
            else
            {
                context.Entry(CestaBasica).State = EntityState.Modified;
            }

            context.Entry(familia).State = EntityState.Modified;
            context.Entry(secretaria).State = EntityState.Modified;
            context.Entry(user).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }


        public CestaBasica PreencherCestaBasica(DTOCestaBasica cestaBasicaDTO)
        {
            var enderecoDTO = cestaBasicaDTO.Endereco;
            var endereco = cestaBasicaDTO.Endereco.ConverterDTOParaModel(enderecoDTO.Id,enderecoDTO.Logradouro,enderecoDTO.CEP,enderecoDTO.Rua,enderecoDTO.Bairro);
            var familia = cestaBasicaDTO.Familia.ConverterDTOParaModel(cestaBasicaDTO.Familia,endereco);
            var solicitadoPor = cestaBasicaDTO.Solicitacao.SolicitadoPor.ConverterParaModel(cestaBasicaDTO.Solicitacao.SolicitadoPor);

            var cestaBasica = cestaBasicaDTO.ConverterDTOParaModel(endereco, familia,
                cestaBasicaDTO.SolcitacaoID, cestaBasicaDTO.Solicitacao.NumeroProtocolo,
                cestaBasicaDTO.Solicitacao.Descricao, cestaBasicaDTO.Solicitacao.StatusSolicitacao);
            cestaBasica.SolicitadoPor = solicitadoPor;

            return cestaBasica;


        }
    }
}
