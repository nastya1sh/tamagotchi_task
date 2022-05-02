namespace tamagotchi_task.Domain.Entities
{
    public class Fur: DomainEntity
    {
        public string Image { get; set; }
        [Required(ErrorMessage = "Choose the fur!")]
        public string Type { get; set; }
        public Avatar Avatar { get; set; }
    }
}
