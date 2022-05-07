using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface ITaskManager
    {
        Task<CharacterTask> FindTaskByName (string taskName); /*поиск задач по названию*/
        Task<CharacterTask> FindTaskByID(Guid taskID); /*поиск задач по ID*/
        Task AddTaskToDataBase(
            Guid taskID, string name, string description, string difficulty,
            string tag, DateTime deadLine, Character character); /*добавление задачи*/
        void DeleteTask (Guid taskID); /*удаление задачи*/
        public IQueryable<CharacterTask> GetAll();
    }
}
