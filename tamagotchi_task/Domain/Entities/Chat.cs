namespace tamagotchi_task.Domain.Entities
{
    public class Chat : DomainEntity
    {
        public List<Message> Messages { get; set; }
        public List<MyUser> MyUsers { get; set; }
    }
}
