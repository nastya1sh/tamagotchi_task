namespace tamagotchi_task.Managers.Interfaces
{
    public interface IInventoryManager
    {
        Task UseItem(Character character, Guid itemID);
        public IQueryable<Inventory> GetItems(Character chara);
    }
}
