using Core.Repository;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure;

namespace API_GAMA
{
    public static class ExtensionServiceCollection
    {
        public static IServiceCollection AddCidadaoAdapter(this IServiceCollection services)
        {
            return services.AddScoped<ICidadaoRepository, CidadaoRepositorySQL>().AddScoped<ICidadaoService, CidadaoService>();           

        }

        public static IServiceCollection AddCargoAdapter(this IServiceCollection services) 
        {
            return services.AddScoped<ICargoRepository, CargoRepositorySQL>().AddScoped<ICargoService, CargoService>();
        }
        
        public static IServiceCollection AddCestaBasicaAdpater(this IServiceCollection services)
        {
            return services.AddScoped<ICestaBasicaRepository, CestaBasicaRepositorySQL>().AddScoped<ICestaBasicaService, CestaBasicaService>();
        }
        public static IServiceCollection AddChamadoAdapter(this IServiceCollection services)
        {
            return services.AddScoped<IChamadoRepository, ChamadoRepositorySQL>().AddScoped<IChamadoService, ChamadoService>();
        }
        public static IServiceCollection AddEnderecoAdapter(this IServiceCollection services) 
        {
            return services.AddScoped<IEnderecoRepository,EnderecoRepositorySQL>().AddScoped<IEnderecoService,EnderecoService>();
        }
        public static IServiceCollection AddFamiliaAdapter(this IServiceCollection services)
        {
            return services.AddScoped<IFamiliaRepository, FamiliaRepositorySQL>().AddScoped<IFamiliaService,FamiliaService>();
        }
        public static IServiceCollection AddReclamacaoAdapter(this IServiceCollection services)
        {
            return services.AddScoped<IReclamacaoRepository,ReclamacaoRepositorySQL>().AddScoped<IReclamacaoService,ReclamacaoService>();
        }
        public static IServiceCollection AddSecretariaAdapter(this IServiceCollection services)
        {
            return services.AddScoped<ISecretariaRepository,SecretariaRepositorySQL>().AddScoped<ISecretariaService,SecretariaService>();
        }
        public static IServiceCollection AddServidorAdapter(this IServiceCollection services)
        {
            return services.AddScoped<IServidorRepository,ServidorRepositorySQL>().AddScoped<IServidorService,ServidorService>();
        }

        public static IServiceCollection AddLoginAdapter(this IServiceCollection services)
        {
            return services.AddScoped<ILoginService, LoginService>();
        }

    }
}
