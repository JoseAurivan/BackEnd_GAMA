using Core.Entities;
using Core.Repository;
using Infrastructure.DataBaseModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CidadaoRepositorySQL : ICidadaoRepository
    {
        private Context context;

        public CidadaoRepositorySQL(Context context)
        {
            this.context = context;
        }

        public async Task<Cidadao> AuthenticateCidadao(string cpf, string password)
        {
           var cidadaoDTO = await context.Cidadoes
                .Include(x => x.User)
                .Where(x => x.User.CPF == cpf && x.User.Senha == password)
                .FirstOrDefaultAsync();

            if(cidadaoDTO is not null)
                return cidadaoDTO.ConverterDTOParaModel(cidadaoDTO);

            return null;
        }

        public async Task DeleteCidadaoAsync(Cidadao cidadao)
        {
            var userDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == cidadao.Id);
            
            context.Users.Remove(userDTO);
            await context.SaveChangesAsync();
        }

        public async Task<Cidadao>? GetCidadaoByIdAsync(int id)
        {
            var cidadaoDTO = await context.Cidadoes.Where(x => x.UserId == id).Include(x => x.User).FirstOrDefaultAsync();

            return cidadaoDTO.ConverterDTOParaModel(cidadaoDTO);
                
        }

        public async Task<IEnumerable<Cidadao>> GetCidadaos()
        {

            var cidadoDTOList = await context.Cidadoes.ToListAsync<DTOCidadao>();
            List<Cidadao> cidadaos = new List<Cidadao>();
            foreach(DTOCidadao cidadao in cidadoDTOList)
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == cidadao.UserId);
                cidadao.User = user;
                cidadaos.Add(cidadao.ConverterDTOParaModel(cidadao));
            }
            return cidadaos;
        }


        public async Task SaveCidadaoAsync(Cidadao cidadao)
        {
            var userDTO = new DTOUser(cidadao.Nome,cidadao.CPF,cidadao.Senha, cidadao.Email, cidadao.Telefone);
            var cidadaoDTO = new DTOCidadao(userDTO, cidadao.PISPASEP);
            if (cidadao.Id == default)
            {
                context.Users.Add(userDTO);
                context.Cidadoes.Add(cidadaoDTO);

            }
            else
            {
                context.Entry(userDTO).State = EntityState.Modified;
                context.Entry(cidadaoDTO).State = EntityState.Modified;  
            }

            await context.SaveChangesAsync();
        }
    }
}