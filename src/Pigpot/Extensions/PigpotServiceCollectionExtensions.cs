using Pigpot;
using Pigpot.Azure;
using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class PigpotServiceCollectionExtensions
    {      
        public static IServiceCollection AddPigpot(this IServiceCollection services, Action<PigpotOptions> setup = null)
        {
            PigpotOptions options = new PigpotOptions();

            setup?.Invoke(options);

            services.AddSingleton<IContextFactory>(options.ContextFactory);
            services.AddSingleton<ICatalogResolver>(options.CatalogResover);
            services.AddSingleton<IRepositoryFilter>(options.RepositoryFilter);

            services.AddSingleton<IRequestHandler, GetSingle>();
            services.AddSingleton<IRequestHandler, GetAll>();
            services.AddSingleton<IRequestHandler, AddSingle>();
            services.AddSingleton<IRequestHandler, UpdateSingle>();
            services.AddSingleton<IRequestHandler, AddOrUpdateSingle>();
            services.AddSingleton<IRequestHandler, DeleteSingle>();

            services.AddSingleton<IPigpot, PigpotService>();

            return services;
        }

        public static IServiceCollection AddAzureBlobStorageForPigpot(this IServiceCollection services, Action<AzureBlobSettings> setup)
        {
            AzureBlobSettings settings = new AzureBlobSettings();

            setup(settings);

            services.AddSingleton<IAzureBlobStorage>(new AzureBlobStorage(settings));

            return services;
        }

    }
}