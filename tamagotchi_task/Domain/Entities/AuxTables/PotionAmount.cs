namespace tamagotchi_task.Domain.Entities.AuxTables
{
    public class PotionAmount : DomainEntity
    {
        public int Amount { get; set; }

        public Potions Potion { get; set; }
        public Character Character { get; set; }
    }
}
