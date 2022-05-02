namespace tamagotchi_task.Domain.Entities
{
    public class Showcase : DomainEntity
    {
        public int Item_Id { get; set; }
        public string Item_Type{ get; set; }
        public string Item_Name { get; set; }
        public int Price { get; set; }

        public List<Toys> Toys { get; set; }
        public List<Potions> Potions { get; set; }
        public List<Forage> Forages { get; set; }
    }
}
