namespace tamagotchi_task.Domain.Entities
{
    public class Potions : DomainEntity
    {
        public string Image { get; set; }
        public int Buff_XP { get; set; }

        //public PotionCharacter PotionCharacters { get; set; }
        public Showcase Showcases { get; set; }
        public List<PotionCharacter> PotionCharacters { get; set; }
    }
}
