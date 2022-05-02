namespace tamagotchi_task.Domain.Entities
{
    public class Fur: DomainEntity
    {
        public string Image { get; set; }
        public string Type { get; set; }

        public Avatar Avatars { get; set; }
    }
}
