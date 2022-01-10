using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Json;
using EsriService.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using EsriService.Services;

namespace EsriService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEsriService _esriService;
        private HttpClient _client;

        public Worker(ILogger<Worker> logger, IEsriService esriService)
        {
            _logger = logger;
            _esriService = esriService;
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
                    var states = await _esriService.GetStatesFromDb();
                    var isSuccess = await _esriService.GetStatesFromApi(_client);                 
                    
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
