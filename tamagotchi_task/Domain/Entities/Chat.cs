namespace tamagotchi_task.Domain.Entities
{
    public class Chat : DomainEntity
    {
        [Required]
        public int Participants { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
        public Chats_Users Chats_Users { get; set; }
    }
}
