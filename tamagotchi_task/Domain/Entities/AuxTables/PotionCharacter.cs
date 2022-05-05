using tamagotchi_task.Domain.Entities.AuxTables;

namespace tamagotchi_task.Domain.Entities
{
    public class PotionCharacter
    {
        public Guid Id { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Potions> Potions { get; set; } = new List<Potions>();
        public List<PotionAmount> PotionAmounts { get; set; } = new List<PotionAmount>();
    }
}
