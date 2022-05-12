using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface IChatManager
    {
        public Task<Chat> FindChatByName(string chatName); 
        public Task SendMessage(string text,Chat chat, MyUser MyUser); // отправить сообщение в форум (1)
        // получать текст, chat и userid
        public ICollection<Message> WriteNLastMessages(Chat chat); // показать 10 последних сообщений в форуме (2)
       
        public string WriteChatName(Chat chat); // возврашает имя чата (3)

        public ICollection<MyUser> WriteAllUsers(Chat chat); // возврашает пользователей чата (4)

    }
}
