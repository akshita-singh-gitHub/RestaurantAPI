using Microsoft.EntityFrameworkCore;

namespace restaurant.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<RestoList> Listresto => Set<RestoList>() ;

        public DbSet<Orders> OrderList => Set<Orders>();


       /* internal Task EditRestoListAsync(int id)
        {
            throw new NotImplementedException();
        }*/
    } 
    
}
