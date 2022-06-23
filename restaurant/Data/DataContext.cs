using Microsoft.EntityFrameworkCore;

namespace restaurant.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<RestoList> Listresto => Set<RestoList>() ;
    }
}
