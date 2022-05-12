namespace tamagotchi_task.Domain.Entities
{
    public class Message 
    {
        [Key]
        public Guid Id { get; set; } 
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Sending_Time { get; set; }

        public Chat Chat { get; set; }
        public Guid ChatId { get; set; }
        public MyUser MyUser { get; set; }
        public Guid MyUserId { get; set; }

    }
}
