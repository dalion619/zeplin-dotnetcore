using System;
using Microsoft.Extensions.DependencyInjection;
using Zeplin.NetCore.RestClient.Interfaces;
using Zeplin.NetCore.RestClient.Options;
using Zeplin.NetCore.RestClient.Services;

namespace Zeplin.NetCore.RestClient.Extensions
{
    /// <summary>
    ///     Adds Zeplin Rest Client service to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="setupAction">
    ///     An <see cref="Action{T}" /> to configure the provided. <see cref="ZeplinRestClientOptions" />
    /// </param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static class ZeplinRestClientServiceCollectionExtensions
    {
        public static IServiceCollection AddZeplinRestClientService(this IServiceCollection services,
            Action<ZeplinRestClientOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            services.AddOptions();
            services.Configure(setupAction);
            services.Add(ServiceDescriptor.Singleton<IZeplinRestClient, ZeplinRestClient>());

            return services;
        }
    }
}