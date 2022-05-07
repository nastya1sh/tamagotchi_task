using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface IShowcaseManager
    {
        public Task<Showcase> FindShowcaseByID(Guid showcaseID);
        public void BuyItem(Guid characterID, int item_Id);
        public IQueryable<Showcase> ShowAll();

    }
}
