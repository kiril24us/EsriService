using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EsriService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EsriService
{
    public class Worker : BackgroundService
    {
        public IServiceScopeFactory _serviceScopeFactory;
        private HttpClient _client;

        public Worker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var esriService = scope.ServiceProvider.GetService<IEsriService>();
                        await esriService.GetStatesFromApi(_client);

                    }                                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                TimeSpan oneWeek = new TimeSpan(4, 12, 0, 0) + new TimeSpan(2, 12, 0, 0);

                await Task.Delay(oneWeek, stoppingToken);
            }
        }
    }
}
