using Microsoft.EntityFrameworkCore;

namespace restaurant.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<RestoList> Listresto => Set<RestoList>() ;

        public DbSet<Orders> OrderList => Set<Orders>();
        public DbSet<FoodDetail> RestoMenu => Set<FoodDetail>();
        public DbSet<UserDb> UserList => Set<UserDb>();
        public DbSet<CartDb> CartList => Set<CartDb>();


      
    } 
    
}
