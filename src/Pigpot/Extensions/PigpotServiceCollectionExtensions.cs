using Pigpot;
using Pigpot.Azure;
using System;
using Pigpot.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class PigpotServiceCollectionExtensions
    {
        public static IServiceCollection AddPigpot(this IServiceCollection services, Action<PigpotOptions> setup = null)
        {
            PigpotOptions options = new PigpotOptions();

            setup?.Invoke(options);

            services.AddSingleton<IRequestContextFactory>(options.RequestContextFactoryType);
            services.AddSingleton<IRepositoryFilter>(options.RepositoryFilterType);
            services.AddSingleton<ICatalogResolver>(options.CatalogResoverType);
            services.AddSingleton<IPigpot>(options.PigpotServiceType);

            foreach (Type type in options.RequestHandlerTypes)
            {
                services.AddSingleton<IRequestHandler>(type);
            }

            if (options.AddHttpContextAccessor)
            {
                services.AddHttpContextAccessor();
            }

            return services;
        }

        public static IServiceCollection AddAzureBlobStorageForPigpot(this IServiceCollection services, Action<AzureBlobSettings> setup)
        {
            AzureBlobSettings settings = new AzureBlobSettings();

            setup(settings);

            services.AddSingleton<IAzureBlobStorage>(new AzureBlobStorage(settings));
            services.AddSingleton<IRepository, AzureBlobRepository>();

            return services;
        }

        private static void AddSingleton<T>(this IServiceCollection services, Type type)
        {
            services.Add(ServiceDescriptor.Describe(typeof(T), type, ServiceLifetime.Singleton));
        }
    }
}