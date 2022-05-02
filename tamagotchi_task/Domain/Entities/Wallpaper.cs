namespace tamagotchi_task.Domain.Entities
{
    public class Wallpaper : DomainEntity
    {
        [Required(ErrorMessage = "There should be a background!")]
        public string Image { get; set; }
        public Avatar Avatar { get; set; }
    }
}
