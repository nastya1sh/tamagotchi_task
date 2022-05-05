namespace tamagotchi_task.Domain.Entities
{
    public class Chat : DomainEntity
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        public List<MyUser> MyUsers { get; set; } = new List<MyUser>();
    }
}
