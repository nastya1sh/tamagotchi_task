namespace tamagotchi_task.Domain.Entities
{
    public class Massage : DomainEntity
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Sending_Time { get; set; }
        public LoginUser User { get; set; }
        public Chat Chat { get; set; }

    }
}
