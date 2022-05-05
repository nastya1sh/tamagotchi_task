using tamagotchi_task.Domain.Entities.AuxTables;

namespace tamagotchi_task.Domain.Entities
{
    public class ToyCharacter : DomainEntity
    { 
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Toys> Toys { get; set; } = new List<Toys>();
        public List<ToyAmount> ToyAmounts { get; set; } = new List<ToyAmount>();
    }
}
