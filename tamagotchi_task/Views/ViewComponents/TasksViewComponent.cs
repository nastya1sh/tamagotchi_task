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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
            
            var tasks = _taskManager.GetTasks(chara);

            return View(tasks);
        }
    }
}
