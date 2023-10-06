using Core.Entities;
using Core.Repository;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ChamadoService : IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepositoy;

        public ChamadoService(IChamadoRepository chamadoRepository)
        {
            _chamadoRepositoy = chamadoRepository;
        }

        public async Task DeleteChamadoAsync(Chamado chamado)
        {
            try
            {
                await _chamadoRepositoy.DeleteChamadoAsync(chamado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task SaveChamadoAsync(Chamado chamado)
        {
            try
            {
                await _chamadoRepositoy.SaveChamadooAsync(chamado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Chamado> GetChamadoByIdAsync(int id)
        {
            try
            {
                return await _chamadoRepositoy.GetChamadoByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Chamado>> GetChamadosFromSecretaria(int secretariaId)
        {
            try
            {
                return await _chamadoRepositoy.GetChamadosFromSecretaria(secretariaId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Chamado>> GetChamadosAsync()
        {
            try
            {
                return await _chamadoRepositoy.GetChamados();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
