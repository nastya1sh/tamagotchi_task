namespace tamagotchi_task.Domain.Entities
{
    public class Wallpaper : DomainEntity
    {
        public string Image { get; set; }

        public Avatar Avatars { get; set; }
    }
}
