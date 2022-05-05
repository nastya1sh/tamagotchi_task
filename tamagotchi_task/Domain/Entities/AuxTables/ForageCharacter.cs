using tamagotchi_task.Domain.Entities.AuxTables;

namespace tamagotchi_task.Domain.Entities
{
    public class ForageCharacter : DomainEntity
    {
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Forage> Forages { get; set; } = new List<Forage>();
        public List<ForageAmount> ForageAmounts { get; set; } = new List<ForageAmount>();
    }
}
