namespace tamagotchi_task.Domain.Entities
{
    public class Accessories : DomainEntity
    {
        public string Image { get; set; }

        public Avatar Avatars { get; set; }
    }
}
