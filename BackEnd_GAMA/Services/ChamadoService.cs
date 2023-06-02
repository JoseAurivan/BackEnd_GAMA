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
    public class ChamadoService:IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepositoy;

        public ChamadoService(IChamadoRepository chamadoRepository)
        {
            _chamadoRepositoy = chamadoRepository;
        }

        public async Task DeleteChamadoAsync(Chamado chamado) => await _chamadoRepositoy.DeleteChamadoAsync(chamado);
        public async Task SaveChamadoAsync(Chamado chamado) => await _chamadoRepositoy.SaveChamadooAsync(chamado);
        public async Task<Chamado> GetChamadoByIdAsync(int id)
        {
            return await _chamadoRepositoy.GetChamadoByIdAsync(id);
        }
        public async Task<IEnumerable<Chamado>> GetChamadosAsync()
        {
            return await _chamadoRepositoy.GetChamados();
        }



    }
}
