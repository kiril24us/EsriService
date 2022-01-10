using EsriService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EsriService.Repositories
{
    public interface IStateRepository
    {
        Task AddState(State state);

        Task<List<State>> GetStatesFromDb();
    }
}
