using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface IShowcaseManager
    {
        public Task<Showcase> FindShowcaseByID(Guid showcaseID);
        public Task BuyItem(Character character, Guid showcaseID);
        public IQueryable<Showcase> GetItems(Character character);
    }
}
