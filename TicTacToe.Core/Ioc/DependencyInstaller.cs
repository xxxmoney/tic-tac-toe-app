using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Services;

namespace TicTacToe.Core.Ioc
{
    public static class DependencyInstaller
    {
        /// <summary>
        /// Builds configuration from appsettings.json.
        /// </summary>
        /// <returns></returns>
        private static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            return builder.Build();
        }

        /// <summary>
        /// Installs logger.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static IServiceCollection InstallLogger(IServiceCollection services, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(configuration)
                   .CreateLogger();

            return services.AddSingleton<ILogger>(logger);
        }

        /// <summary>
        /// Installs core services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection Install(IServiceCollection services)
        {
            services.AddTransient<IGameManager, GameManager>();
            services.AddSingleton<IBoardInitBuilder, BoardBuilder>();
            services.AddSingleton<IGameInitBuilder, GameBuilder>();

            // Installs configuration.
            var configuration = BuildConfiguration();
            services.AddSingleton(configuration);

            // Installs logger.
            InstallLogger(services, configuration);

            return services;
        }

    }
}
