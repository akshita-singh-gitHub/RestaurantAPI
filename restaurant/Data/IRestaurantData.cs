namespace restaurant.Data
{
    //public interface IUserData
    //{
    //    void RegisterUser(UserDb details);
    //    UserDb GetLoginUser(UserDb data);
    //    List<UserDb> DeleteUser(int id);
    //}
   

    public interface IRestoListData
    {
        List<RestoList> GetRestoList();
        List<RestoList> CreateRestoList(RestoList details);
        List<RestoList> UpdateRestoList(RestoList details, int id);
        void DeleteRestoList(RestoList dbresto);
        RestoList GetRestoById(int id);
        //void SetAvailability(RestoList resto);

    }

    public interface ICartData
    {
        List<CartDb> GetUserCartItems(int UserId);
        String EmptyCartList(List<CartDb> cart);
        String ModifyCartItems(CartDb Cart);
       
        //String AddCartItem(CartDb cart, string item);
        //List<CartDb> DeleteUserCart(CartDb user);
        //CartDb CreateUserCart(CartDb details);



    }

    public interface IMenuData
    {
        List<FoodDetail> GetMenuList();
        FoodDetail getFoodById(int id);
        List<FoodDetail> GetRestoByName(string restaurant);
        List<FoodDetail> GetFoodDetail(string[] CartArray);
        List<FoodDetail> GetFoodByTag(string Tag);

        void SetFoodAvailability(FoodDetail  Food);
        void DeleteFoodItem(FoodDetail Food);
        List<FoodDetail> AddFoodItem(FoodDetail details);
        List<FoodDetail> UpdateFoodItem(FoodDetail details, int id);



    }

}
