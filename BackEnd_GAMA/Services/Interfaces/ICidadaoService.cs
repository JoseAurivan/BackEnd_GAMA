using Core.Entities;

namespace Core.Services.Interfaces
{
    public interface ICidadaoService
    {
        Task<Cidadao> GetCidadaoById(int id);
        Task<Cidadao> GetCidadaoByCPFAsync(string cpf);
        Task DeleteCidadaoAsync(Cidadao cidadao);
        Task<int> SaveCidadaoAsync(Cidadao cidadao);
        Task<IEnumerable<Cidadao>> GetAllCidadao();
    }
}