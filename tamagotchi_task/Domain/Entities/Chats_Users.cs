namespace tamagotchi_task.Domain.Entities
{
    public class Chats_Users : DomainEntity /*таблица чаты-пользователи*/
    {
        //связи один ко многим
        public List<MyUser> MyUsers { get; set; } = new List<MyUser>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
