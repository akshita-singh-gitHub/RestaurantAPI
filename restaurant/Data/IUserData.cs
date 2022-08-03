namespace restaurant.Data
{
    public interface IUserData
    {
        void RegisterUser(UserDb details);
        UserDb GetLoginUser(UserDb data);
        List<UserDb> DeleteUser(int id);
    }
}
