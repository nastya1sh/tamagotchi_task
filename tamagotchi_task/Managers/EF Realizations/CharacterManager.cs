using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Models.ViewModels;

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

        public async Task SetAvatar(Character character, AvatarModel model) 
        {
            //И тут менеджер внезапно узнал о представлении AvatarModel, что не совсем ладится с принятой нами схемой
            //Но строгое следование паттернам иногда тоже выглядит несколько странно
            character.AnimalImage = model.Animal;
            character.ColorImage = model.Color;
            character.WallpaperImage = model.Wallpaper;
            character.AccessoryImage = model.Accessory;
            await _db.SaveChangesAsync();
        }
    }
}
