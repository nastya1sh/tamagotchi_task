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
            Character temp = new Character
            {
                Id = characterID,
                Name = characterName,
                MyUsers = user,
            };
            user.Characters.Add(temp);
            _db.Characters.Add(temp);

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

        public async Task<Character> FindCharacterByUser(string userName)
        {
            return await _db.Characters.FirstOrDefaultAsync(u => u.MyUsers.Name == userName);
        }

        public void SetAnimal(Character character, string image)
        {
            character.AnimalImage = image;
            _db.SaveChanges();
        }
        public void SetColor(Character character, string image)
        {
            character.ColorImage = image;
            _db.SaveChanges();
        }
        public void SetWallpaper(Character character, string image)
        {
            character.WallpaperImage = image;
            _db.SaveChanges();
        }
        public void SetAccessory(Character character, string image)
        {
            character.AccessoryImage = image;
            _db.SaveChanges();
        }
    }
}
