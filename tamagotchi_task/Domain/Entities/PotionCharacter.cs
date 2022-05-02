namespace tamagotchi_task.Domain.Entities
{
    public class PotionCharacter : DomainEntity
    {
        public int Amount { get; set; }

        public List<Character> Characters { get; set; }
        public List<Potions> Potions { get; set; }
    }
}
