using tamagotchi_task.Domain;

namespace tamagotchi_task.Managers.Interfaces
{
    public interface ITaskManager
    {
        Task<CharacterTask> FindTaskByName (string taskName); /*поиск задач по названию*/
        Task AddTaskToDataBase(Guid taskID, string description, string difficulty, DateTime deadLine, TagsTasks tagsTasks); /*добавление задачи*/
        void DeleteTask (Guid taskID); /*удаление задачи*/

    }
}
