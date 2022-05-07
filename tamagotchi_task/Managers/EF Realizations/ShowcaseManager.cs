using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Managers.EF_Realizations
{
    public class ShowcaseManager : IShowcaseManager
    {
        private readonly AppDbContext _db;
        public ShowcaseManager(AppDbContext context)
        {
            _db = context;
        }
        public async Task<Showcase> FindShowcaseByID(Guid showcaseID)
        {
            return await _db.Showcases.FirstOrDefaultAsync(u => u.Id == showcaseID);
        }
        public async void BuyItem(Guid characterID, int item_Id)
        {
            int balance = _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().Money ;         
            int cost = _db.Showcases.Where(u => u.Item_Id == item_Id).FirstOrDefault().Price;
            if (balance >= cost)
                _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().Money -= cost;
            await _db.SaveChangesAsync();
        }
        public IQueryable<Showcase> ShowAll()
        {

            return  _db.Showcases;
        }
    }
}
