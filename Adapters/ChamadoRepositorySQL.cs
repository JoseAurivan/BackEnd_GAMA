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
            try
            {
                var chamadoDTO = context.Chamados.Where(x => x.SolicitacaoId == Chamado.Id).Include(x => x.Solicitacao).FirstOrDefault();
                context.Solicitacoes.Remove(chamadoDTO.Solicitacao);
                context.Chamados.Remove(chamadoDTO);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<Chamado> GetChamadoByIdAsync(int id)
        {
            try
            {
                var chamadoDTO = await context.Chamados.Where(x => x.SolicitacaoId == id).Include(x => x.Solicitacao).FirstOrDefaultAsync();
                var solicitadoPorDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SolicitadoPorId);
                var atendidoPorDTO = await context.Servidores.FirstOrDefaultAsync(x => x.UserId == chamadoDTO.Solicitacao.AtendidoPorId);
                var secretariaDTO = await context.Secretarias.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SecretariaId);

                if (atendidoPorDTO is not null)
                    return chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO, atendidoPorDTO);

                return chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO);
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Chamado>> GetChamados()
        {
            try
            {
                var chamadosDTO = await context.Chamados.Include(x => x.Solicitacao).ToListAsync();
                List<Chamado> chamados = new List<Chamado>();
                foreach (DTOChamado chamadoDTO in chamadosDTO)
                {
                    var solicitadoPorDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SolicitadoPorId);
                    var atendidoPorDTO = await context.Servidores.FirstOrDefaultAsync(x => x.UserId == chamadoDTO.Solicitacao.AtendidoPorId);
                    var secretariaDTO = await context.Secretarias.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SecretariaId);
                    if (atendidoPorDTO is not null)
                        chamados.Add(chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO, atendidoPorDTO));
                    else
                    {
                        chamados.Add(chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO));
                    }
                }
                return chamados;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<IEnumerable<Chamado>> GetChamadosFromSecretaria(int secretariaId)
        {
            try
            {
                var chamadosDTO = await context.Chamados.Include(x => x.Solicitacao).Where(x => x.Solicitacao.SecretariaId == secretariaId).ToListAsync();
                List<Chamado> chamados = new List<Chamado>();
                foreach (DTOChamado chamadoDTO in chamadosDTO)
                {
                    var solicitadoPorDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SolicitadoPorId);
                    var atendidoPorDTO = await context.Servidores.FirstOrDefaultAsync(x => x.UserId == chamadoDTO.Solicitacao.AtendidoPorId);
                    var secretariaDTO = await context.Secretarias.FirstOrDefaultAsync(x => x.Id == chamadoDTO.Solicitacao.SecretariaId);
                    if(atendidoPorDTO is not null)
                        chamados.Add(chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO, atendidoPorDTO));
                    else
                    {
                        chamados.Add(chamadoDTO.ConverterDTOParaModel(chamadoDTO, secretariaDTO, solicitadoPorDTO));
                    }
                }
                
                return chamados;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SaveChamadooAsync(Chamado Chamado)
        {
            try
            {
                var secretaria = await context.Secretarias.FirstOrDefaultAsync(x => x.Id == Chamado.SecretariaDestino.Id);
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Chamado.SolicitadoPor.Id);
                

                var solicitacaoDTO = new DTOSolicitacao(Chamado.Descricao, Chamado.Descricao,
                    Chamado.StatusSolicitacao, secretaria.Id, user.Id, Chamado.Inicio);

                var chamadoDTO = new DTOChamado(solicitacaoDTO, Chamado.StatusAtendimento, Chamado.Telefone);

                if (Chamado.Id == default)
                {
                    await context.Solicitacoes.AddAsync(solicitacaoDTO);
                    await context.SaveChangesAsync();
                    chamadoDTO.SolicitacaoId = solicitacaoDTO.Id;
                    await context.Chamados.AddAsync(chamadoDTO);

                }
                else
                {
                    solicitacaoDTO.Id = Chamado.Id;
                    chamadoDTO.SolicitacaoId = solicitacaoDTO.Id;
                    context.Entry(solicitacaoDTO).State = EntityState.Modified;
                    context.Entry(chamadoDTO).State = EntityState.Modified;
                }

                context.Entry(secretaria).State = EntityState.Modified;
                context.Entry(user).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
