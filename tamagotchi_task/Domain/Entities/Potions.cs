namespace tamagotchi_task.Domain.Entities
{
    public class Potions : DomainEntity
    {
        public int Buff_XP { get; set; }

        //public PotionCharacter PotionCharacters { get; set; }
        public List<Showcase> Showcases { get; set; }
    }
}
