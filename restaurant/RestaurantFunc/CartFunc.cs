namespace restaurant.Data
{
    public class CartFunc : ICartData
    {
        private readonly DataContext _context;

        public CartFunc(DataContext context)
        {
            _context = context;
        }

       public CartDb GetUserCartItems(int Id)
        {
            var Cart = _context.CartList.Find( Id);
            
                return Cart;
          

        }
        public String EmptyCartList(CartDb cart)
        {
            cart.CartItems = null;

             _context.SaveChanges();

            return cart.CartItems;
        }
        public String ModifyCartItems(CartDb cart, string item)
        {
            string str2;
            int pos1 = cart.CartItems.IndexOf(item);

            if (pos1 == 0)
                str2 = cart.CartItems.Remove(pos1, item.Length + 1);

            else
                str2 = cart.CartItems.Remove(pos1 - 1, item.Length + 1);

            cart.CartItems = str2;

             _context.SaveChanges();

            return cart.CartItems;
        }
        public String SaveOrder(CartDb order, string item)
        {
            if (order.OrderHistory == null)
                order.OrderHistory = item;
            else
                order.OrderHistory = order.OrderHistory.Insert(0, item + ",");

             _context.SaveChanges();

            return order.OrderHistory;

        }
        public String AddCartItem(CartDb cart, string item)
        {
            if (cart.CartItems == null)
                cart.CartItems = item;
            else
                cart.CartItems = cart.CartItems.Insert(0, item + ",");

             _context.SaveChanges();

            return cart.CartItems;
        }
        public List<CartDb> DeleteUserCart(CartDb user)
        {
            _context.CartList.Remove(user);
             _context.SaveChanges();
            return  _context.CartList.ToList();
        }
        public CartDb CreateUserCart(CartDb details)
        {
          _context.CartList.Add(details);
             _context.SaveChanges();
            var cart = _context.CartList.Find(details.Id);
            cart.CartItems = null;
             _context.SaveChanges();

            return cart;
        }

    }
}
