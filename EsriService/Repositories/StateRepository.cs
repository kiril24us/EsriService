using EsriService.Models;
using EsriService.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EsriService.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _appDbContext;

        public StateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddState(State state)
        {
            await _appDbContext.States.AddAsync(state);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<State>> GetStatesFromDb()
        {
            return await _appDbContext.States.ToListAsync();
        }
    }
}
