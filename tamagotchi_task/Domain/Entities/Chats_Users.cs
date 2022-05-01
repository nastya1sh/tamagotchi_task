namespace tamagotchi_task.Domain.Entities
{
    public class Chats_Users : DomainEntity /*таблица чаты-пользователи*/
    {
        //связи один ко многим
        public List<LoginUser> LoginUsers { get; set; } = new List<LoginUser>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
