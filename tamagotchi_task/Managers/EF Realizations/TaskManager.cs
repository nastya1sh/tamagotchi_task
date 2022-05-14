using Microsoft.EntityFrameworkCore;
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

        public bool HasCorrectDate(DateTime time) 
        {
            if (time <= DateTime.Now) return false;
            return true;
        }

        public async Task AddTaskToDataBase(
            Guid taskID, string name, string description, string difficulty,
            string tag, DateTime deadLine, Character character)
        {
            _db.CharacterTasks.Add(new CharacterTask 
            { 
                Id = taskID,
                Name = name,
                Description= description
                , Difficulty= difficulty,
                Tag = tag,
                DeadLine = deadLine,
                Characters = character
            });
            await _db.SaveChangesAsync();                  
        }

        /// <summary>
        /// Проверяет сроки всех заданий. Если какие-то задачи просрочены, то отнимает жизни персонажа в соответствии с приоритетом.
        /// </summary>
        /// <returns>
        /// Возвращает элемент типа Character или null, если character.HP <= 0 после выполнения метода.
        /// </returns>
        public async Task<Character> CheckTasks(Character character) 
        {
            foreach (var task in _db.CharacterTasks.Where(u => u.DeadLine < DateTime.Now && u.Characters.Id == character.Id)) 
            {
                if (task == null) break;
                task.Characters.HP -= Convert.ToInt32(task.Difficulty); //У нас приоритет, по сути, Enum
                _db.CharacterTasks.Remove(task);
            }
            if (character.HP <= 0) _db.Characters.Remove(character);

            _db.SaveChanges();
            return character;
        }

        public async Task CompleteTask(Guid taskID, Character character) 
        {
            CharacterTask task = await _db.CharacterTasks.FirstOrDefaultAsync(t => t.Id == taskID);
            character.XP += (int)Math.Pow(2, Convert.ToInt32(task.Difficulty));
            character.Money += 2 * Convert.ToInt32(task.Difficulty);
            if (task.Tag == "Sport")
                character.Strength += Convert.ToInt32(task.Difficulty);
            else if (task.Tag == "Study")
                character.Intellect += Convert.ToInt32(task.Difficulty);

            _db.CharacterTasks.Remove(task);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteTask(Guid taskID)
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
        public IQueryable<CharacterTask> GetTasks(Character chara)
        {
            return _db.CharacterTasks.Where(u => u.Characters == chara);
        }
    }
}
