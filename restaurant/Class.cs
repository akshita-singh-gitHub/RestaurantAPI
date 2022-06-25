    namespace restaurant
{
    public class RestoList
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    } 
    public class Orders
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
