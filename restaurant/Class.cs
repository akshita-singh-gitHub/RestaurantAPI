    namespace restaurant
{
    public class RestoList
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Available { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

    } 
    public class Orders
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    } 
    public class FoodDetail
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Restaurant { get; set; } = string.Empty;
        public string Favourite { get; set; } = string.Empty;
        public int Price { get; set; } 
        public string CookTime { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string? Tag { get; set; } = string.Empty;
        public string? Available { get; set; } = string.Empty;

    }
    public class UserDb
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; } = string.Empty;
      
        


    }
    public class CartDb
    {

        
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? CartItems { get; set; } = string.Empty;
        public string? OrderHistory { get; set; } = string.Empty;
        
        
    }
}
