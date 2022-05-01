namespace tamagotchi_task.Domain.Entities
{
    public class Showcase : DomainEntity
    {
        public int Item_Id { get; set; }
        public string Item_Type{ get; set; }
        public string Item_Name { get; set; }
        public int Price { get; set; }
        public List<Toys> Toys { get; set; } = new List<Toys>();
        public List<Potions> Poutions { get; set; } = new List<Potions>();
        public List<Forage> Forage { get; set; } = new List<Forage>();

    }
}
