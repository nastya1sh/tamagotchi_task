namespace tamagotchi_task.Domain.Entities.AuxTables
{
    public class ForageAmount : DomainEntity
    {
        public int Amount { get; set; }

        public Forage Forage { get; set; }
        public Character Character { get; set; }
    }
}
