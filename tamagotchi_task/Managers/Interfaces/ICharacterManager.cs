using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface ICharacterManager
    {
        Task AddCharacterToDataBase(Guid characterID, MyUser user, string characterName); /*добавление персонажа с заданным именем*/
        void DeleteCharacterDataBase(Guid characterID);
        Task<Character> FindCharacterByID(Guid characterID); /*поиск персонажа по ID*/
        public Task<Character> FindCharacterByUser(string userName);
        public void SetAnimal(Character character, string image);
        public void SetColor(Character character, string image);
        public void SetWallpaper(Character character, string image);
        public void SetAccessory(Character character, string image);
    }
}
