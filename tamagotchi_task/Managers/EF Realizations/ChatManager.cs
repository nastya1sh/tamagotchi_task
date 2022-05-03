using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Managers.EF_Realizations
{
    public class ChatManager : IChatManager
    {
        private readonly AppDbContext _db;

        public ChatManager(AppDbContext context)
        {
            _db = context;
        }

        public async Task<Chat> FindChatByName(string chatName) 
        {
            return await _db.Chats.FirstOrDefaultAsync(c => c.Name == chatName);
        }
    }
}
