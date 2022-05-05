namespace tamagotchi_task.Domain.Entities.AuxTables
{
    public class ForageAmount
    {
        public Guid Id { get; set; }
        public Guid ForageId { get; set; }
        public Guid CharacterId { get; set; }
        public int Amount { get; set; }

        //public Forage Forage { get; set; }
        //public Character Character { get; set; }
    }
}
