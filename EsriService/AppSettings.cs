using Microsoft.Extensions.Configuration;

namespace EsriService
{
    public static class AppSettings
    {
        public static IConfiguration Configuration { get; set; }
        public static string ConnectionString { get; set; }
    }
}
