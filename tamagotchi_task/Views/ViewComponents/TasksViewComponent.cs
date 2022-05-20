using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Views.ViewComponents
{
    public class TasksViewComponent : ViewComponent
    {
        private readonly ITaskManager _taskManager;
        private readonly ICharacterManager _characterManager;

        public TasksViewComponent(ITaskManager taskManager, ICharacterManager characterManager)
        {
            _characterManager = characterManager;
            _taskManager = taskManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string searchString)
        {
            Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
            
            var tasks = _taskManager.GetTasks(chara);

            if (!String.IsNullOrEmpty(searchString))
            {
                tasks = tasks.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(tasks);
        }
    }
}
