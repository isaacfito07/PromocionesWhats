using Microsoft.Extensions.Configuration;
using System.IO;

namespace PromWhats // ← cámbialo si es necesario
{
    public static class AppConfig
    {
        public static IConfiguration Configuration { get; private set; }

        static AppConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetConnectionString(string name)
        {
            return Configuration.GetConnectionString(name);
        }

        public static string GetValue(string key)
        {
            return Configuration[key];
        }
    }
}
