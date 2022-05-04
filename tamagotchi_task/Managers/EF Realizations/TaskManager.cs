using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Managers.EF_Realizations
{
    public class TaskManager : ITaskManager
    {
        private readonly AppDbContext _db;

        public TaskManager(AppDbContext context)
        {
            _db = context;
        }
        public async Task AddTaskToDataBase(Guid taskID, string description, string difficulty, DateTime deadLine, TagsTasks tagsTasks)
        {
            if (DateTime.Compare(DateTime.Now, deadLine)<0) /*если дедлайн в будущем*/
            {
                _db.CharacterTasks.Add(new CharacterTask { Id = taskID, Description= description , Difficulty= difficulty, DeadLine= deadLine, TagsTasks= tagsTasks});
                await _db.SaveChangesAsync();
            }
            else
            {
                //здесь выводится сообщение об ошибке, хз как сделать
            }                       
        }

        public async void DeleteTask(Guid taskID)
        {
            _db.CharacterTasks.Remove(new CharacterTask() { Id = taskID });
            await _db.SaveChangesAsync();
        }

        public async Task<CharacterTask> FindTaskByName(string taskName)
        {
            return await _db.CharacterTasks.FirstOrDefaultAsync(u => u.Name == taskName);
        }
        public async Task<CharacterTask> FindTaskByID(Guid taskID)
        {
            return await _db.CharacterTasks.FirstOrDefaultAsync(u => u.Id == taskID);
        }
    }
}
