namespace tamagotchi_task.Domain.Entities
{
    public class Message : DomainEntity
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Sending_Time { get; set; }

        public MyUser MyUsers { get; set; }
        public Chat Chats { get; set; }
    }
}
