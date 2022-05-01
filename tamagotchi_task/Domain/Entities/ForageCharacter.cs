namespace tamagotchi_task.Domain.Entities
{
    public class ForageCharacter
    {
        public int Amount { get; set; }
        public List<Character> Character { get; set; } = new List<Character>();
        public List<Forage> Forage { get; set; } = new List<Forage>();
    }
}
