namespace tamagotchi_task.Domain.Entities
{
    public class Chat : DomainEntity
    {
        [Required]
        public int Participants { get; set; }
        public List<Massage> Massages { get; set; } = new List<Massage>();
        public Chats_Users Chats_Users { get; set; }
    }
}
