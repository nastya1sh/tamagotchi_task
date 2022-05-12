using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Models.ViewModels;

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

        
        //public void SendMessage(string text, Chat chat, string username)
        //{
        //   Task<Chat> chat1 = _db.Chats.FirstOrDefaultAsync(c => c.Name == "GlobalChat");
        //        _db.Chats.
        //}

        public ICollection<Message> WriteNLastMessages(Chat chat)
        {
            int N = 10;
            // return   _db.Messages.Reverse().Take(N).ToList(); // реверс нельзя 
            return _db.Messages.Take(N).ToList();
        }

        public ICollection<MyUser> WriteAllUsers(Chat chat)
        {
            return chat.MyUsers;
        }

        public string WriteChatName(Chat chat)
        {
            return chat.Name;
        }

        public async Task SendMessage(string text, Chat chat, MyUser MyUser)
        {
            _db.Messages.Add(new Message
            { 
                Id = Guid.NewGuid(),
                Text = text,
                Sending_Time = DateTime.Now,
                Chat = chat,
                MyUser = MyUser,
                ChatId= chat.Id,
                MyUserId= chat.Id
            });
            _db.SaveChanges();
        }
    }
}
