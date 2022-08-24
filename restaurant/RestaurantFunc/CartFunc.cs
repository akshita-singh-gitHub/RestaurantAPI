namespace restaurant.Data
{
    public class CartFunc : ICartData
    {
        private readonly DataContext _context;

        public CartFunc(DataContext context)
        {
            _context = context;
        }

       public List<CartDb> GetUserCartItems(int UserId)
        {
            var cart = _context.CartList.Where(x => x.UserId == UserId).ToList();
            return cart;

        }
        public String EmptyCartList(List<CartDb> cart)
        {
            for(int i = 0; i < cart.Count; i++)
                _context.CartList.Remove(cart[i]);
            
            _context.SaveChanges();

            return "" ;
        }
        public String ModifyCartItems(CartDb Cart)
        {


            _context.CartList.Remove(Cart);
            _context.SaveChanges();

            return "modified";
        }


        public CartDb AddCartItem(int userId, string customerName , int foodId)
        {

            FoodDetail foodItem = new FoodDetail();
            MenuFunc menuFunc = new MenuFunc(_context);
            foodItem = menuFunc.getFoodById(foodId);
            
                CartDb cart = new CartDb();

               
                cart.CustomerName = customerName;
                cart.UserId = userId;
                cart.Restaurant = foodItem.Restaurant;
            cart.ImageUrl = foodItem.ImageUrl;
            cart.CartItems = foodItem.Name;
            cart.Price = foodItem.Price;

            _context.CartList.Add(cart);

                _context.SaveChanges();
            
        

            return cart;
        }



    }
}
