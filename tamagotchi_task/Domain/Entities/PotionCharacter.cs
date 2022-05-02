namespace tamagotchi_task.Domain.Entities
{
    public class PotionCharacter : DomainEntity
    {
        public int Amount { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Potions> Potions { get; set; } = new List<Potions>();
    }
}
