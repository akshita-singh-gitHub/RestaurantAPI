namespace restaurant.Data
{
    public class MenuFunc : IMenuData
    {
        private readonly DataContext _context;

        public MenuFunc(DataContext context)
        {
            _context = context;
        }
        public List<FoodDetail> GetMenuList()
        {
            return _context.RestoMenu.ToList();
        }
        public FoodDetail getFoodById(int id)
        {
            var dbresto =  _context.RestoMenu.Find(id);

            return dbresto;
        }

        public List<FoodDetail> GetRestoByName(string restaurant)
        {
            var resto = _context.RestoMenu.Where(x => x.Restaurant == restaurant).ToList();
            return resto;
        }


      

        public List<FoodDetail> GetFoodDetail(string[] CartArray)
        {
            List<FoodDetail> UserCart = new List<FoodDetail>();
            for (int i = 0; i < CartArray.Length; i++)
            {
                var item = _context.RestoMenu.Where(x => x.Name == CartArray[i]).FirstOrDefault();

                UserCart.Add(item);

            }
            return UserCart;
        }

        public List<FoodDetail> GetFoodByTag(string Tag)
        {
            var item = _context.RestoMenu.Where(x => x.Tag == Tag).ToList();
            return item;
        }


      

        public void SetFoodAvailability(FoodDetail Food)
        {
            if (Food.Available == "true")
                Food.Available = "false";
            else Food.Available = "true";
            _context.SaveChanges();
        }

        public void DeleteFoodItem(FoodDetail Food)
        {
            _context.RestoMenu.Remove(Food);
            _context.SaveChanges();
        }

        public List<FoodDetail> AddFoodItem(FoodDetail details)
        {
            _context.RestoMenu.Add(details);
            _context.SaveChanges();

            return _context.RestoMenu.ToList();
        }

        public List<FoodDetail> UpdateFoodItem(FoodDetail details, int id)
        {
            var dbresto = _context.RestoMenu.Find(details.Id);
            if (dbresto != null)
            {

                dbresto.Name = details.Name;
                dbresto.Restaurant = details.Restaurant;
                dbresto.Price = details.Price;
                dbresto.CookTime = details.CookTime;
                dbresto.Tag = details.Tag;
                dbresto.ImageUrl = details.ImageUrl;
                dbresto.Available = details.Available;
                dbresto.Favourite = details.Favourite;
            }
            _context.SaveChanges();


            return _context.RestoMenu.ToList();
        }
    }
}
