namespace tamagotchi_task.Domain.Entities
{
    public class ForageCharacter : DomainEntity
    {
        public int Amount { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Forage> Forages { get; set; } = new List<Forage>();
    }
}
