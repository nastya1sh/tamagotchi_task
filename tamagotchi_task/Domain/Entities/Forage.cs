namespace tamagotchi_task.Domain.Entities
{
    public class Forage : DomainEntity //корм
    {
        public string Image { get; set; }
        public int Buff_HP { get; set; }

        //public ForageCharacter ForageCharacters { get; set; }
        public Showcase Showcases { get; set; }
        public List<ForageCharacter> ForageCharacters { get; set; }
    }
}
