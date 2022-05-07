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

    public IActionResult Index()
    {
        //Атрибут [Authorize] не видит аутентифицированного пользователя
        //Поэтому пришлось вставить старый добрый костыль
        if (User.Identity.IsAuthenticated)
        {
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
            //Добавляем задачу в бд
            await _taskManager.AddTaskToDataBase(Guid.NewGuid(), model.Name, model.Description, model.Difficulty, model.Tag, model.DeadLine);

            return View();
        }
        else //Должно выскакивать при пустых полях задачи
            ModelState.AddModelError("", "This task is incomplete!");
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult ViewCharacter ()   
    {
        var animal = _characterManager.FindCharacterByUser(User.Identity.Name);
        return View();
    }
}