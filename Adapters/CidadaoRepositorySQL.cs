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
            try { 
            var cidadaoDTO = await context.Cidadoes
                 .Include(x => x.User)
                 .Where(x => x.User.CPF == cpf && x.User.Senha == password)
                 .FirstOrDefaultAsync();

            if (cidadaoDTO is not null)
                return cidadaoDTO.ConverterDTOParaModel(cidadaoDTO);

            return null;
            }catch(Exception ex) { throw; }
        }

        public async Task DeleteCidadaoAsync(Cidadao cidadao)
        {
            try { 
            var userDTO = await context.Users.FirstOrDefaultAsync(x => x.Id == cidadao.Id);

            context.Users.Remove(userDTO);
            await context.SaveChangesAsync();
            }catch(Exception ex) { throw; }
    }

        public async Task<Cidadao>? GetCidadaoByIdAsync(int id)
        {
            try
            {
                var cidadaoDTO = await context.Cidadoes.Where(x => x.UserId == id).Include(x => x.User).FirstOrDefaultAsync();

                return cidadaoDTO.ConverterDTOParaModel(cidadaoDTO);
            }
            catch (Exception ex) { throw; }

        }
        public async Task<Cidadao> GetCidadaoByCPFAsync(string cpf)
        {
            try
            {
                var cidadaoDTO = await context.Cidadoes
                    .Include(x => x.User)
                    .Where(x => x.User.CPF == cpf)
                    .FirstOrDefaultAsync();

                return cidadaoDTO.ConverterDTOParaModel(cidadaoDTO);
            }
            catch (Exception ex) { throw; }

        }

        public async Task<IEnumerable<Cidadao>> GetCidadaos()
        {
            try
            {
                var cidadoDTOList = await context.Cidadoes.ToListAsync<DTOCidadao>();
                List<Cidadao> cidadaos = new List<Cidadao>();
                foreach (DTOCidadao cidadao in cidadoDTOList)
                {
                    var user = await context.Users.FirstOrDefaultAsync(x => x.Id == cidadao.UserId);
                    cidadao.User = user;
                    cidadaos.Add(cidadao.ConverterDTOParaModel(cidadao));
                }
                return cidadaos;
            }
            catch (Exception ex) { throw; }
        }


        public async Task<int> SaveCidadaoAsync(Cidadao cidadao)
        {

            try
            {

                if (cidadao.Id == default)
                {
                    var userDTO = new DTOUser(cidadao.Nome, cidadao.CPF, cidadao.Senha, cidadao.Endereco.Id, cidadao.Email, cidadao.Telefone);
                    var cidadaoDTO = new DTOCidadao(userDTO, cidadao.PISPASEP);

                    context.Users.Add(userDTO);
                    await context.SaveChangesAsync();

                    cidadaoDTO.UserId = userDTO.Id;
                    context.Cidadoes.Add(cidadaoDTO);
                    await context.SaveChangesAsync();
                    return userDTO.Id;

                }
                else
                {
                    var userDTO = new DTOUser(cidadao.Id,cidadao.Nome, cidadao.CPF, cidadao.Senha, cidadao.Email, cidadao.Telefone);
                    var cidadaoDTO = new DTOCidadao(userDTO, cidadao.PISPASEP);
                    context.Entry(userDTO).State = EntityState.Modified;
                    context.Entry(cidadaoDTO).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return userDTO.Id;
                }
            }
            catch (Exception ex)
            {
                throw;
            }




        }
    }
}