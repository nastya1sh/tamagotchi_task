using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface ITaskManager
    {
        Task<CharacterTask> FindTaskByName (string taskName); /*поиск задач по названию*/
        Task<CharacterTask> FindTaskByID(Guid taskID); /*поиск задач по ID*/
        public bool HasCorrectDate(DateTime time);
        public Task<Character> CheckTasks(Character character);
        public Task CompleteTask(Guid taskID, Character character);
        Task AddTaskToDataBase(
            Guid taskID, string name, string description, string difficulty,
            string tag, DateTime deadLine, Character character); /*добавление задачи*/
        public Task DeleteTask (Guid taskID); /*удаление задачи*/
        public IQueryable<CharacterTask> GetAll();
    }
}
