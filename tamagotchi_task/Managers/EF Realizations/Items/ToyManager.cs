using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces.ItemInterfaces;

namespace tamagotchi_task.Managers.EF_Realizations.Items
{
    public class ToyManager : IToyManager
    {
        private readonly AppDbContext _db;

        public ToyManager(AppDbContext context)
        {
            _db = context;
        }

        public async Task DecreaseAmount(Guid itemCharacterID)
        {
            ToyCharacter pc = await _db.ToyCharacters.FirstOrDefaultAsync(c => c.Id == itemCharacterID);
            if (pc != null)
            {
                pc.Amount -= 1; //Убираем элемент при использовании
                //Удаляем элемент таблицы, если эликсиров вообще не осталось
                if (pc.Amount <= 0)
                    _db.ToyCharacters.Remove(pc);

                await _db.SaveChangesAsync();
            }
        }

        public async Task<Guid> FindItemCharacterAsync(Guid characterID, Guid itemID)
        {
            IQueryable<Character> characters =
                _db.Characters.Where(c => c.Id == characterID); //Ищем персонажей с таким ID
            if (characters == null) //Если их нет, то нам делать нечего
                return Guid.Empty; //То же самое, что и return null;

            IQueryable<Toys> toys =
                _db.Toys.Where(d => d.Id == itemID); //Ищем нужные эликсиры

            return await _db.ToyCharacters //Возвращаем элемент таблицы ToyCharacters
                .Where(pc => pc.Characters == characters) //со всеми записями, имеющими нужного перса,
                .Where(pc => pc.Toys == toys) //но с одной искомой записью, совпадающей по персу-эликсиру
                .Select(pc => pc.Id) //Конвертируем список с класса ToyCharacter в Guid
                .FirstOrDefaultAsync(); //Отбираем оттуда один элемент
        }

        public IQueryable GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
