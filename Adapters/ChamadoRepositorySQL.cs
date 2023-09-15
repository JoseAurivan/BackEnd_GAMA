using Core.Entities;
using Core.Entities.Abstract;
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
    public class ChamadoRepositorySQL : IChamadoRepository
    {
        private Context context;

        public ChamadoRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task DeleteChamadoAsync(Chamado Chamado)
        {
            var chamadoDTO = context.Chamados.Where(x => x.SolicitacaoId == Chamado.Id).Include(x => x.Solicitacao).FirstOrDefault();
            context.Chamados.Remove(chamadoDTO);
            context.Solicitacoes.Remove(chamadoDTO.Solicitacao);
            await context.SaveChangesAsync();
        }

        public async Task<Chamado> GetChamadoByIdAsync(int id)
        {
            var chamadoDTO = await context.Chamados.Where(x => x.SolicitacaoId == id).Include(x => x.Solicitacao).FirstOrDefaultAsync();
            var solicitadoPorDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SolicitadoPorId);
            var atendidoPorDTO = await context.Servidores.FirstOrDefaultAsync( x=> x.UserId == chamadoDTO.Solicitacao.AtendidoPorId);
            var secretariaDTO = await context.Secretarias.FirstOrDefaultAsync( x=> x.Id == chamadoDTO.Solicitacao.SecretariaId);

            return chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO, atendidoPorDTO);

        }

        public async Task<IEnumerable<Chamado>> GetChamados()
        {
            var chamadosDTO = await context.Chamados.Include(x => x.Solicitacao).ToListAsync();
            List<Chamado> chamados = new List<Chamado>();
            foreach(DTOChamado chamadoDTO in chamadosDTO)
            {
                var solicitadoPorDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SolicitadoPorId);
                var atendidoPorDTO = await context.Servidores.FirstOrDefaultAsync(x => x.UserId == chamadoDTO.Solicitacao.AtendidoPorId);
                var secretariaDTO = await context.Secretarias.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SecretariaId);
                chamados.Add(chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO, atendidoPorDTO));
            }
            return chamados;
            
        }

        public async Task SaveChamadooAsync(Chamado Chamado)
        {
            var secretaria = await context.Secretarias.FirstOrDefaultAsync(x => x.Id == Chamado.SecretariaDestino.Id);
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Chamado.SolicitadoPor.Id);
            var servidor =await context.Servidores.FirstOrDefaultAsync(x => x.UserId == Chamado.AtendidoPor.Id);

            var solicitacaoDTO = new DTOSolicitacao(Chamado.Descricao,Chamado.Descricao,
                Chamado.StatusSolicitacao,secretaria,user,servidor,Chamado.Inicio,Chamado.Fim);

            var chamadoDTO = new DTOChamado(solicitacaoDTO,Chamado.StatusAtendimento,Chamado.Telefone);

            secretaria.Solicitacoes.Add(solicitacaoDTO);
            user.Solicitacao.Add(solicitacaoDTO);

            if (Chamado.Id == default)
            {
                await context.Chamados.AddAsync(chamadoDTO);
                await context.Solicitacoes.AddAsync(solicitacaoDTO);
            }
            else
            {
                context.Entry(chamadoDTO).State = EntityState.Modified;
                context.Entry(solicitacaoDTO).State = EntityState.Modified;
            }

            context.Entry(servidor).State = EntityState.Modified;
            context.Entry(secretaria).State = EntityState.Modified;
            context.Entry(user).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
