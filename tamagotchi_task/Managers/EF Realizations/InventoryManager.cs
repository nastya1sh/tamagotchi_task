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
            Inventory item = await _db.Inventories.FirstOrDefaultAsync(u => u.Id == itemID && u.CharacterId == character.Id);

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

        /// <summary>
        /// Возвращает коллекцию всех вещей из инвентаря, кроме аксессуаров.
        /// </summary>
        /// <param name="chara"></param>
        /// <returns>IQuariable коллекцию, закрытую типом данных Inventory.</returns>
        public IQueryable<Inventory> GetItems(Character chara)
        {
            //Возвращаем все предметы в инвентаре, отсортированные по типу
            return _db.Inventories.Where(u => u.Character == chara && u.Item_Type != "Accessories").OrderBy(item => item.Item_Type);
        }

        /// <summary>
        /// Возвращает коллекцию вещей из инвентаря, в которой присутствуют только аксессуары.
        /// </summary>
        /// <param name="chara"></param>
        /// <returns>IQuariable коллекцию, закрытую типом данных Inventory.</returns>
        public IQueryable<Inventory> GetAccessories(Character chara)
        {
            return _db.Inventories.Where(u => u.Character == chara && u.Item_Type == "Accessories");
        }
    }
}
