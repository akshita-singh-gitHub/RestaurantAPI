namespace restaurant
{
    public class UserDto
    {
        public string Email { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;
    }

    public class OrderDto
    {
        public string CustomerName { get; set; } = string.Empty;
        
        public string Order { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
