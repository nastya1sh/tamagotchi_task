using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Models;
using tamagotchi_task.Models.ViewModels;

namespace tamagotchi_task.Controllers;
public partial class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    private readonly ITaskManager _taskManager;
    private readonly ICharacterManager _characterManager;
    

    public HomeController(ITaskManager taskManager, ICharacterManager characterManager)
    {
        _taskManager = taskManager;
        _characterManager = characterManager;
    }

    public async Task<IActionResult> Index()
    {
        //Атрибут [Authorize] не видит аутентифицированного пользователя
        //Поэтому пришлось вставить старый добрый костыль
        if (User.Identity.IsAuthenticated)
        {
            Character temp = await _characterManager.FindCharacterByUser(User.Identity.Name);
            if (await _taskManager.CheckTasks(temp) == null)
                return RedirectToAction("Dead", "Character"); //Потом пропишу страницу смерти животного
            return View();
        }
        else
            return RedirectToAction("Login", "Account");
    }
    [HttpPost]
    public async Task<IActionResult> Index(TaskModel model)
    {
        if (ModelState.IsValid)
        {
            //Проверяем дату
            if (!_taskManager.HasCorrectDate(model.DeadLine))
            {
                ModelState.AddModelError("", "The date of the task is in the past!");
                return View(model);
            }

            //Ищем животное, которому присвоится это задание
            Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
            //Добавляем задачу в бд
            await _taskManager.AddTaskToDataBase(
                Guid.NewGuid(), model.Name, model.Description, model.Difficulty,
                model.Tag, model.DeadLine, chara);

            return View();
        }
        else //Должно выскакивать при пустых полях задачи
            ModelState.AddModelError("", "The task is incomplete!");
        return View(model);
    }

    public async Task<IActionResult> Complete(Guid taskID) 
    {
        await _taskManager.CompleteTask(taskID);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult ViewCharacter ()   
    {
        var animal = _characterManager.FindCharacterByUser(User.Identity.Name);
        return View();
    }
}