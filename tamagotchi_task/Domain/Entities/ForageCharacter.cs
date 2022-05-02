namespace tamagotchi_task.Domain.Entities
{
    public class ForageCharacter : DomainEntity
    {
        public int Amount { get; set; }

        public List<Character> Characters { get; set; }
        public List<Forage> Forages { get; set; }
    }
}
