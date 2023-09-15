using Core.Entities;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FamiliaRepositorySQL : IFamiliaRepository
    {
        private Context context;
        public async Task DeleteFamiliaAsync(Familia Familia)
        {
            DTOFamilia familiaDTO = await context.Familias.FirstOrDefaultAsync(x => x.Id == Familia.Id);
            context.Familias.Remove(familiaDTO);
            await context.SaveChangesAsync();
        }

        public async Task<Familia> GetFamiliaByIdAsync(int id)
        {
            var familiaDTO = await context.Familias.Where(x => x.Id == id)
                .Include(x => x.Endereco)
                .Include(x => x.Membros)
                .Include(x => x.Cestas)
                .ThenInclude(x => x.Solicitacao)
                .FirstOrDefaultAsync();

            var membrosDTO = familiaDTO.Membros;
            var cestasDTO = familiaDTO.Cestas;
            var enderecoDTO = familiaDTO.Endereco;


            List<Cidadao> membros = new List<Cidadao>();
            List<CestaBasica> cestas = new List<CestaBasica>();
            Endereco endereco = enderecoDTO.ConverterDTOParaModel(enderecoDTO.Id, enderecoDTO.Logradouro, enderecoDTO.CEP, enderecoDTO.Rua, enderecoDTO.Bairro);
            Familia familia = familiaDTO.ConverterDTOParaModel(familiaDTO, endereco);

            foreach (var membro in membrosDTO)
            {
                membros.Add(membro.ConverterDTOParaModel(membro));
            }

            familia.Membros = membros;
            foreach (var cesta in cestasDTO)
            {
                cestas.Add(cesta.ConverterDTOParaModel(endereco, familia,
                    cesta.SolcitacaoID, cesta.Solicitacao.NumeroProtocolo,
                    cesta.Solicitacao.Descricao, cesta.Solicitacao.StatusSolicitacao));
            }

            familia.Cestas = cestas;

            return familia;

        }

        public async Task<IEnumerable<Familia>> GetFamilias()
        {
            var familiasDTO = await context.Familias
                .Include(x => x.Endereco)
                .Include(x => x.Membros).ToListAsync();

            List<Familia> familias = new List<Familia>();

            foreach(var familiaDTO in familiasDTO )
            {
                var enderecoDTO = familiaDTO.Endereco;
                var membrosDTO = familiaDTO.Membros;
                
                Endereco endereco = enderecoDTO.ConverterDTOParaModel(enderecoDTO.Id, enderecoDTO.Logradouro, enderecoDTO.CEP, enderecoDTO.Rua, enderecoDTO.Bairro);
                List<Cidadao> membros = new List<Cidadao>();
                var familia = familiaDTO.ConverterDTOParaModel(familiaDTO, endereco);

                foreach (var membro in membrosDTO)
                {
                    membros.Add(membro.ConverterDTOParaModel(membro));
                }

                familia.Membros = membros;
                familias.Add(familia);
                
            }
            return familias;
                
        }

        public async Task SaveFamiliaAsync(Familia Familia)
        {
            
            DTOEndereco enderecoDTO = await context.Enderecos.FirstOrDefaultAsync(x => x.Id == Familia.Endereco.Id);
            DTOFamilia familiaDTO = new DTOFamilia();
            familiaDTO.EnderecoId = enderecoDTO.Id;
            if (Familia.Id == default) context.Familias.Add(familiaDTO);
            else context.Entry(Familia).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
