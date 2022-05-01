namespace tamagotchi_task.Domain.Entities
{
    public class Forage : DomainEntity
    {
        public string Image { get; set; }

        public int Buff_HP { get; set; }
        public ForageCharacter ForageCharacter { get; set; }
        public Showcase Showcase { get; set; }
    }
}
