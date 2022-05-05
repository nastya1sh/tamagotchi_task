namespace tamagotchi_task.Domain.Entities.AuxTables
{
    public class ToyAmount : DomainEntity
    {
        public int Amount { get; set; }

        public Toys Toy { get; set; }
        public Character Character { get; set; }
    }
}
