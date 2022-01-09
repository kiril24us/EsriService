using EsriService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EsriService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            CreateDatabaseIfNotExist(host);

            host.Run();
        }

        private static void CreateDatabaseIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    AppSettings.Configuration = configuration;
                    AppSettings.ConnectionString = configuration.GetConnectionString("DefaultConnection");

                    var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
                    optionBuilder.UseSqlServer(AppSettings.ConnectionString);

                    services.AddScoped<AppDbContext>(d => new AppDbContext(optionBuilder.Options));

                    services.AddHostedService<Worker>();
                });
    }
}
