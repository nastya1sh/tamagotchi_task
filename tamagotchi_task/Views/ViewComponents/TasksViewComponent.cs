using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Views.ViewComponents
{
    public class TasksViewComponent : ViewComponent
    {
        private readonly ITaskManager _taskManager;

        public TasksViewComponent(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        public IViewComponentResult Invoke()
        {
            var tasks = _taskManager.GetAll();

            return View(tasks);
        }
    }
}
