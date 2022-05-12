using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Managers.EF_Realizations
{
    public class MyUserManager : IUserManager
    {
        private readonly AppDbContext _db;

        public MyUserManager(AppDbContext context) 
        {
            _db = context;
        }

        public async Task<MyUser> FindUserByNameAsync(string userName)
        {
            return await _db.MyUsers.FirstOrDefaultAsync(u => u.Name == userName);
        }

        public Character HasAnimal(Guid userID) 
        {
            //Поскольку у пользователя нет ссылки на животное,
            //пришлось вставить такой костыль
            return _db.Characters.FirstOrDefault(u => u.MyUsers.Id == userID);
        }

        public async Task<MyUser> FindUserByNamePasswordAsync(string userName, string userPassword) 
        {
            return await _db.MyUsers.FirstOrDefaultAsync(u => u.Name == userName && u.Password == userPassword);
        }

        public async Task AddUserToDataBase(Guid userID, string userName, string userPassword, Chat chat) 
        {
            _db.MyUsers.Add(new MyUser { Id = userID, Name = userName, Password = userPassword, Chats = chat });
            await _db.SaveChangesAsync();
        }
    }
}
