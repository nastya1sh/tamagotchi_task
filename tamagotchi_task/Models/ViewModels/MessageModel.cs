namespace tamagotchi_task.Models.ViewModels
{
    public class MessageModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Sending_Time { get; set; }

        public Chat Chat { get; set; }
        public Guid ChatId { get; set; }
    }
}
