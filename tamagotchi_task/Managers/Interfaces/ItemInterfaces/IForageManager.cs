namespace tamagotchi_task.Managers.Interfaces.ItemInterfaces
{
    public interface IForageManager
    {
        /// <summary>
        /// Возвращает коллекцию IQueryable из базы данных.
        /// </summary>
        public IQueryable GetItems();
        /// <summary>
        /// Декрементирует количество данного предмета в инвентаре,
        /// если элемент таблицы ForageManager с таким ID был найден.
        /// </summary>
        /// <param name="itemCharacterID"></param>
        /// <returns>
        /// Декрементирует свойство Amount или удаляет элемент таблицы,
        /// при его значении Amount меньше или равном 0.
        /// </returns>
        public Task DecreaseAmount(Guid itemCharacterID);
        /// <summary>
        /// Ищет элемент таблицы ForageManager по ID персонажа и ID предмета.
        /// </summary>
        /// <param name="characterID"></param>
        /// <param name="itemID"></param>
        /// <returns>
        /// Возвращает ID элемента с совпадающими столбцами или "пустой" ID в обратном случае.
        /// </returns>
        public Task<Guid> FindItemCharacterAsync(Guid characterID, Guid itemID);
    }
}
