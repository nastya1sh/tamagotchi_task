using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces.ItemInterfaces;

namespace tamagotchi_task.Managers.EF_Realizations.Items
{
    public class ForageManager : IForageManager
    {
        private readonly AppDbContext _db;

        public ForageManager(AppDbContext context)
        {
            _db = context;
        }

        public async Task DecreaseAmount(Guid itemCharacterID)
        {
            ForageCharacter pc = await _db.ForageCharacters.FirstOrDefaultAsync(c => c.Id == itemCharacterID);
            if (pc != null)
            {
                pc.Amount -= 1; //Убираем элемент при использовании
                //Удаляем элемент таблицы, если корма вообще не осталось
                if (pc.Amount <= 0)
                    _db.ForageCharacters.Remove(pc);

                await _db.SaveChangesAsync();
            }
        }

        public async Task<Guid> FindItemCharacterAsync(Guid characterID, Guid itemID)
        {
            IQueryable<Character> characters =
                _db.Characters.Where(c => c.Id == characterID); //Ищем персонажей с таким ID
            if (characters == null) //Если их нет, то нам делать нечего
                return Guid.Empty; //То же самое, что и return null;

            IQueryable<Forage> forages =
                _db.Forages.Where(d => d.Id == itemID); //Ищем нужный корм

            return await _db.ForageCharacters //Возвращаем элемент таблицы ForageCharacters
                .Where(pc => pc.Characters == characters) //со всеми записями, имеющими нужного перса,
                .Where(pc => pc.Forages == forages) //но с одной искомой записью, совпадающей по персу-корму
                .Select(pc => pc.Id) //Конвертируем список с класса ForageCharacter в Guid
                .FirstOrDefaultAsync(); //Отбираем оттуда один элемент
        }

        public IQueryable GetItems()
        {
            return _db.Forages;
        }
    }
}
