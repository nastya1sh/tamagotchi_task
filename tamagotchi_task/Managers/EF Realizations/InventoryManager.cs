using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Managers.EF_Realizations
{
    public class InventoryManager : IInventoryManager
    {
        private readonly AppDbContext _db;
        public InventoryManager(AppDbContext context)
        {
            _db = context;
        }

        public async Task UseItem(Character character, Guid itemID)
        {
            Inventory item = await _db.Inventories.FirstOrDefaultAsync(u => u.Id == itemID);

            switch (item.Item_Type) 
            {
                case "Forage":
                    var food = await _db.Forages.FirstOrDefaultAsync(u => u.Id == item.ForageId);
                    character.HP += food.Buff_HP;
                    //Персонаж не может иметь больше 6 жизней, но еду всё равно съест
                    if(character.HP > 6)
                        character.HP = 6;
                    break;

                case "Potions":
                    var potion = await _db.Potions.FirstOrDefaultAsync(u => u.Id == item.PotionId);
                    character.XP += potion.Buff_XP;
                    break;

                case "Toys":
                    var toy = await _db.Toys.FirstOrDefaultAsync(u => u.Id == item.ToyId);
                    character.Intellect += toy.Buff_Intellect;
                    character.Strength += toy.Buff_Strength;
                    break;
            }
            if (--item.Amount <= 0)
                _db.Inventories.Remove(item);

            await _db.SaveChangesAsync();
        }

        public IQueryable<Inventory> GetItems()
        {
            return _db.Inventories;
        }
    }
}
