using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductionDirectives.Forms;
using ScottPlot.Colormaps;
using ScottPlot.Statistics;

namespace ProductionDirectives
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //serviceProvider.GetRequiredService<SpiCrawlerDataContext>();
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            var startup = new Startup(configuration);
            startup.ConfigureServices(serviceCollection);
        }
    }
}