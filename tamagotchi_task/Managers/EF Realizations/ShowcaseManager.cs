using Microsoft.EntityFrameworkCore;
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
        public async Task BuyItem(Character character, Guid showcaseID)
        {
            Showcase item = await _db.Showcases.FirstOrDefaultAsync(u => u.Id == showcaseID);

            if (character.Money >= item.Price)
            {
                character.Money -= item.Price;

                Inventory inventory = await _db.Inventories.FirstOrDefaultAsync(u => u.Item_Name == item.Item_Name && u.CharacterId == character.Id);
                if (inventory == null)
                {
                    _db.Inventories.Add(new Inventory
                    {
                        Id = new Guid(),
                        Item_Type = item.Item_Type,
                        Item_Name = item.Item_Name,
                        Image = item.Image,
                        AuxImg = item.AuxImg,
                        Amount = 1,
                        ToyId = item.ToyId,
                        PotionId = item.PotionId,
                        ForageId = item.ForageId,
                        Character = character,
                    });
                }
                else
                    inventory.Amount += 1;
                await _db.SaveChangesAsync();
            }
        }

        public IQueryable<Showcase> GetItems(Character character)
        {
            //Возвращаем все предметы в витрине, отсортированные по типу
            return _db.Showcases.Where(u => u.Level <= character.Level).OrderBy(item => item.Item_Type);
        }
    }
}
