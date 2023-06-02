using Core.Entities;

namespace Core.Services.Interfaces
{
    public interface ICidadaoService
    {
        Task<Cidadao> GetCidadaoById(int id);
        Task DeleteCidadaoAsync(Cidadao cidadao);
        Task SaveCidadaoAsync(Cidadao cidadao);
        Task<IEnumerable<Cidadao>> GetAllCidadao();
    }
}