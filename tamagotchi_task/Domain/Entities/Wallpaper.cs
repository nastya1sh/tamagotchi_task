namespace tamagotchi_task.Domain.Entities
{
    public class Wallpaper : DomainEntity
    {
        [Required(ErrorMessage = "У персонажа должен быть фон!")]
        [Display(Name = "Фон")]
        public string Image { get; set; }
        public Avatar Avatar { get; set; }
    }
}
