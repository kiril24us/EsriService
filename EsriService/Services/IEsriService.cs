using EsriService.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EsriService.Services
{
    public interface IEsriService
    {
        Task<bool> GetStatesFromApi(HttpClient client);

        Task<List<State>> GetStatesFromDb();
    }
}
