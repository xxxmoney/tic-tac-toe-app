using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicTacToe.FormUI.Forms;
using TicTacToe.FormUI.Helpers;

namespace TicTacToe.FormUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Sets up service provider.
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services; 

            // Gets main form from service provider and runs.
            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    // Registers game services from core.
                    Core.Ioc.DependencyInstaller.Install(services);

                    // Registers forms.
                    services.AddTransient<MainForm>();
                    services.AddTransient<GameForm>();
                    services.AddTransient<SettingsForm>();

                    // Registers language switcher.
                    services.AddSingleton<ILanguageSwitcher, LanguageSwitcher>();
                });
        }
    }
}