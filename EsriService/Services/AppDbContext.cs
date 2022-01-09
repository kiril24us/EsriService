using EsriService.Models;
using Microsoft.EntityFrameworkCore;

namespace EsriService.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<State> States { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
