using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces.ItemInterfaces;

namespace tamagotchi_task.Managers.EF_Realizations.Items
{
    public class PotionManager : IPotionManager
    {
        private readonly AppDbContext _db;

        public PotionManager(AppDbContext context)
        {
            _db = context;
        }

        public IQueryable GetItems()
        {
            return _db.Potions;
        }

        public async Task DecreaseAmount(Guid itemCharacterID)
        {
            /*PotionCharacter pc = await _db.PotionCharacters.FirstOrDefaultAsync(c => c.Id == itemCharacterID);
            if (pc != null) 
            {
                pc.Amount -= 1; //Убираем элемент при использовании
                //Удаляем элемент таблицы, если эликсиров вообще не осталось
                if (pc.Amount <= 0)
                    _db.PotionCharacters.Remove(pc);

                await _db.SaveChangesAsync();
            }*/
        }

        public async Task<Guid> FindItemCharacterAsync(Guid characterID, Guid itemID)
        {
            //Я старался следовать KISS. Честно.
            //Этот код крайне не оптимален, но я пытался сделать его понятным
            IQueryable<Character> characters = 
                _db.Characters.Where(c => c.Id == characterID); //Ищем персонажей с таким ID
            if(characters == null) //Если их нет, то нам делать нечего
                return Guid.Empty; //То же самое, что и return null;

            IQueryable<Potions> potions = 
                _db.Potions.Where(d => d.Id == itemID); //Ищем нужные эликсиры

            return await _db.PotionCharacters //Возвращаем элемент таблицы PotionCharacters
                .Where(pc => pc.Characters == characters) //со всеми записями, имеющими нужного перса,
                .Where(pc => pc.Potions == potions) //но с одной искомой записью, совпадающей по персу-эликсиру
                .Select(pc => pc.Id) //Конвертируем список с класса PotionCharacter в Guid
                .FirstOrDefaultAsync(); //Отбираем оттуда один элемент
        }
    }
}
