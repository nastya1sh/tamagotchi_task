using tamagotchi_task.Models.ViewModels;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface ICharacterManager
    {
        Task AddCharacterToDataBase(Guid characterID, MyUser user, string characterName); /*добавление персонажа с заданным именем*/
        void DeleteCharacterDataBase(Guid characterID);
        Task<Character> FindCharacterByID(Guid characterID); /*поиск персонажа по ID*/
        public Task<Character> FindCharacterByUser(string userName);
        public Task SetAvatar(Character character, AvatarModel model);
    }
}
