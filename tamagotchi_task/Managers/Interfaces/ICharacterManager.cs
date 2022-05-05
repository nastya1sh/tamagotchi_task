using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface ICharacterManager
    {
        Task AddCharacterToDataBase(Guid characterID, MyUser user, string characterName); /*добавление персонажа с заданным именем*/
        void DeleteCharacterDataBase(Guid characterID);
        void LevelUP(Guid characterID); /*я так понимаю за раз может увеличиться только на 1*/
        void HpUP(Guid characterID, int value);
        void HpDown (Guid characterID, int value);
        void XpUP(Guid characterID, int value);
        void StrengthUP(Guid characterID, int value);
        void IntellectUP(Guid characterID, int value);
        Task<Character> FindCharacterByID(Guid characterID); /*поиск персонажа по ID*/
    }
}
