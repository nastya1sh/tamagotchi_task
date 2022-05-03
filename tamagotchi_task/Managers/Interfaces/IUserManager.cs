using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface IUserManager
    {
        public Task<MyUser> FindUserByNameAsync(string userName);
        public Task<MyUser> FindUserByNamePasswordAsync(string userName, string userPassword);
        public Task AddUserToDataBase(Guid userID, string userName, string userPassword, Chat chat);
    }
}
