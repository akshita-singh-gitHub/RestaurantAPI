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

            return "Removed";
        }
        public String ModifyCartItems(CartDb Cart)
        {


            _context.CartList.Remove(Cart);
            _context.SaveChanges();

            return "modified";
        }


        //public String AddCartItem(CartDb cart, string item)
        //{

        //    List<CartDb> cart = new List<CartDb>();
        //    MenuFunc menuFunc = new MenuFunc(_context);
        //    OrderDetail = menuFunc.GetFoodDetail(item);
        //    for (int i = 0; i < OrderArr.Length; i++)
        //    {
        //        Orders order = new Orders();

        //        DateTime datetime = DateTime.Now;
        //        order.Datetime = datetime;
        //        order.CustomerName = details.CustomerName;
        //        order.UserId = UserId;
        //        order.Restaurant = OrderDetail[i].Restaurant;
        //        order.Order = OrderDetail[i].Name;
        //        order.Price = OrderDetail[i].Price;
        //        order.imageUrl = OrderDetail[i].ImageUrl;
        //        order.Status = "pending";
        //        order.Address = details.Address;
        //        _context.OrderList.Add(order);

        //        _context.SaveChanges();
        //    }
        //    if (cart.CartItems == null)
        //        cart.CartItems = item;
        //    else
        //        cart.CartItems = cart.CartItems.Insert(0, item + ",");

        //    _context.SaveChanges();

        //    return cart.CartItems;
        //}


        //public List<CartDb> DeleteUserCart(CartDb user)
        //{
        //    _context.CartList.Remove(user);
        //     _context.SaveChanges();
        //    return  _context.CartList.ToList();
        //}
        //public CartDb CreateUserCart(CartDb details)
        //{
        //  _context.CartList.Add(details);
        //     _context.SaveChanges();
        //    var cart = _context.CartList.Find(details.Id);
        //    cart.CartItems = null;
        //     _context.SaveChanges();

        //    return cart;
        //}

    }
}
