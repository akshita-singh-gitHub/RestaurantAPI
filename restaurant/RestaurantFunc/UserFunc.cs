


//namespace restaurant.Data
//{
//    public class UserFunc : IUserData
//    {
//        private readonly DataContext _context;

//        public UserFunc(DataContext context)
//        {
//            _context = context;
//        }

//        public void RegisterUser(UserDb details)
//        {
//            _context.UserList.Add(details);
//             _context.SaveChanges();

            
//        }
       
//        public UserDb GetLoginUser(UserDb data)
//        {
//            var FindUser = _context.UserList.SingleOrDefault(x => x.Email == data.Email && x.Password == data.Password);
           
//                return FindUser ;
           
//        }

//        public List<UserDb> DeleteUser(int id)
//        {
//            var user =  _context.UserList.Find(id);
//           if(user != null)
//            _context.UserList.Remove(user);
//             _context.SaveChanges();

//            return  _context.UserList.ToList();

//        }


//    }


//}
