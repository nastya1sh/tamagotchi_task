using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Managers.EF_Realizations
{
    public class CharacterManager : ICharacterManager
    {
        private readonly AppDbContext _db;

        public CharacterManager(AppDbContext context)
        {
            _db = context;
        }
        public async Task AddCharacterToDataBase(Guid characterID, MyUser user, string characterName)
        {
            Character temp = new Character();
            temp.Id = characterID; temp.Name = characterName; temp.MyUsers = user;
            temp.PotionCharacters = _db.PotionCharacters.First(); //У нас всё равно только один элемент в той таблице
            _db.Characters.Add(new Character { Id = characterID, Name = characterName, MyUsers = user});

            await _db.SaveChangesAsync();
        }

        public async void DeleteCharacterDataBase(Guid characterID)
        {
            _db.Characters.Remove(new Character() { Id = characterID });
            await _db.SaveChangesAsync();
        }

        public async Task<Character> FindCharacterByID(Guid characterID)
        {
            return await _db.Characters.FirstOrDefaultAsync(u => u.Id == characterID);
        }

        public async void HpDown(Guid characterID, int value)
        {
            var character = _db.Characters.Where(u => u.Id == characterID).FirstOrDefault();
            character.HP -= value;
            if (character.HP > 0)
            {
                _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().HP -= value;
                await _db.SaveChangesAsync();
            }
            else
            {
                DeleteCharacterDataBase(characterID);
                await _db.SaveChangesAsync();
            }

        }

        public async void HpUP(Guid characterID, int value)
        {
            _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().HP += value;
            await _db.SaveChangesAsync();
        }

        public async void IntellectUP(Guid characterID, int value)
        {
            _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().Intellect += value;
            await _db.SaveChangesAsync();
        }

        public async void LevelUP(Guid characterID)
        {
            _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().Level += 1;
            await _db.SaveChangesAsync();
        }

        public async void StrengthUP(Guid characterID, int value)
        {
            _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().Strength += value;
            await _db.SaveChangesAsync();
        }

        public async void XpUP(Guid characterID, int value)
        {
            _db.Characters.Where(u => u.Id == characterID).FirstOrDefault().XP += value;
            await _db.SaveChangesAsync();
        }
    }
}
