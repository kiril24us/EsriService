using EsriService.Models;
using EsriService.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EsriService.Services
{
    public class EsriServices : IEsriService
    {
        private readonly IStateRepository _stateRepository;

        public EsriServices(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<bool> GetStatesFromApi(HttpClient client)
        {
            try
            {
                var response = await client.GetAsync("https://services.arcgis.com/P3ePLMYs2RVChkJx/ArcGIS/rest/services/USA_Counties/FeatureServer/0/query?where=1%3D1&outFields=population%2C+state_name&returnGeometry=false&f=pjson");
                var responseAsString = await response.Content.ReadAsStringAsync();

                dynamic locationData = JsonConvert.DeserializeObject<dynamic>(responseAsString);

                foreach (var item in locationData.features)
                {
                    State state = new State()
                    {
                        Name = item.attributes.STATE_NAME,
                        Population = item.attributes.POPULATION
                    };

                    await _stateRepository.AddState(state);
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }

            return true;
        }

        public async Task<List<State>> GetStatesFromDb()
        {
            List<State> allStatesFromDb;

            try
            {
                allStatesFromDb = await _stateRepository.GetStatesFromDb();
            }
            catch (Exception)
            {

                throw;
            }

            return allStatesFromDb;
        }
    }
}
