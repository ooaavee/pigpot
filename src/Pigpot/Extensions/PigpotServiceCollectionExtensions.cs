using Pigpot;
using Pigpot.Azure;
using Pigpot.Services;
using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class PigpotServiceCollectionExtensions
    {
        public static IServiceCollection AddPigpot(this IServiceCollection services, Action<PigpotOptions> setup = null)
        {
            var options = new PigpotOptions();

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

        public static IServiceCollection AddAzureBlobStorageForPigpot(this IServiceCollection services, Action<AzureBlobOptions> setup)
        {
            var options = new AzureBlobOptions();

            // this is the default container name, but can be changed if wanted
            options.ContainerName = "pigpot";

            // by default we use the Windows Azure Emulator, but this value
            // should be replaced with a real connection string
            options.ConnectionString = "UseDevelopmentStorage=true;";

            setup(options);

            services.AddSingleton<IAzureBlobStorage>(new AzureBlobStorage(options));
            services.AddSingleton<IRepository, AzureBlobRepository>();

            return services;
        }

        private static void AddSingleton<T>(this IServiceCollection services, Type type)
        {
            services.Add(ServiceDescriptor.Describe(typeof(T), type, ServiceLifetime.Singleton));
        }
    }
}