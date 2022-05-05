namespace tamagotchi_task.Domain.Entities.AuxTables
{
    public class ToyAmount
    {
        public Guid Id { get; set; }
        public Guid ToyId { get; set; }
        public Guid CharacterId { get; set; }
        public int Amount { get; set; }

        //public Toys Toy { get; set; }
        //public Character Character { get; set; }
    }
}
