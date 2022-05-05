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
        public async Task AddTaskToDataBase(Guid taskID, string description, string difficulty, string tag, DateTime deadLine)
        {
            _db.CharacterTasks.Add(new CharacterTask { Id = taskID, Description= description , Difficulty= difficulty, Tag = tag, DeadLine = deadLine});
            await _db.SaveChangesAsync();                  
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
