namespace tamagotchi_task.Domain.Entities
{
    public class PotionCharacter
    {
        public int Amount { get; set; }
        public List<Character> Character { get; set; } = new List<Character>();
        public List<Potions> Potions { get; set; } = new List<Potions>();
    }
}
