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
                
        public IQueryable<Message> WriteNLastMessages()
        {
            //int N = 10;
            //ICollection<Message> t = new List<Message>();
            //for (int i=chat.Messages.Count; i< chat.Messages.Count-N; i--)
            //{
            //    t.Add( chat.Messages.ElementAt(i));
            //}
            //return t;
            return _db.Messages;
        }

        public ICollection<MyUser> WriteAllUsers(Chat chat)
        {
            return chat.MyUsers;
        }

        public string WriteChatName(Chat chat)
        {
            return chat.Name;
        }

        public async Task SendMessage(string text, Chat chat, MyUser myUser)
        {
            _db.Messages.Add(new Message
            { 
                Id = Guid.NewGuid(),
                Text = text,
                Sending_Time = DateTime.Now,
                Chat = chat,
                MyUser = myUser,
                ChatId= chat.Id,
                MyUserId=myUser.Id,
                MyUserName= myUser.Name
            });
            await _db.SaveChangesAsync();
        }
    }
}
