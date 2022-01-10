using Microsoft.EntityFrameworkCore;

namespace EsriService.Services
{
    public class DbHelper
    {
        private DbContextOptions<AppDbContext> GetAllOptions()
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer(AppSettings.ConnectionString);
            return optionBuilder.Options;
        }

    }
}
