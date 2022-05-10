using tamagotchi_task.Domain;

namespace tamagotchi_task.Models.ViewModels
{
    public class ChatModel
    {
        public List<Message> Messages { get; set; } 
        public List<MyUser> MyUsers { get; set; } 
    }
}
